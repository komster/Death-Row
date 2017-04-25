using System.Collections.Generic;
using UnityEngine;

public class CS_Notify : MonoBehaviour
{

    protected CS_Notify() { }
    static CS_Notify instance;
    static CS_Notify Instance
    {
        get
        {
            if (!instance)
            {
                GameObject notificationObject = new GameObject("CS_Notify");
                instance = notificationObject.AddComponent<CS_Notify>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
        set { }
    }

    Dictionary<string, HashSet<Component>> notifications = new Dictionary<string, HashSet<Component>>();
    List<Event> events = new List<Event>();

    static void InitKey(Dictionary<string, HashSet<Component>> dict, string key)
    {
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, new HashSet<Component>());
        }
    }

    void UpdateCache()
    {
        foreach (Event ev in events)
        {
            switch (ev.action)
            {
                case Action.Register:
                    InitKey(notifications, ev.method);
                    notifications[ev.method].Add(ev.component);
                    break;
                case Action.Unregister:
                    InitKey(notifications, ev.method);
                    notifications[ev.method].Remove(ev.component);
                    break;
                default:
                    break;
            }
        }
        events.Clear();
    }

    void SendMessage(Message message)
    {
        UpdateCache();

        if (string.IsNullOrEmpty(message.method)) { return; }
        if (!notifications.ContainsKey(message.method)) { return; }

        List<Component> remove = new List<Component>();
        foreach (Component observer in notifications[message.method])
        {
            if (observer)
            {
                observer.SendMessage(message.method, message, SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                remove.Add(observer);
            }
        }

        Cleanup(remove, message.method);
    }

    void Cleanup(List<Component> remove, string method)
    {
        foreach (Component observer in remove)
        {
            notifications[method].Remove(observer);
        }
    }

    public static void Register(Component observer, string method)
    {
        if (string.IsNullOrEmpty(method)) { return; }
        Instance.events.Add(new Event(Action.Register, method, observer));
    }

    public static void Unregister(Component observer, string method)
    {
        if (string.IsNullOrEmpty(method)) { return; }
        Instance.events.Add(new Event(Action.Unregister, method, observer));
    }

    public static void Send(Message message)
    {
        Instance.SendMessage(message);
    }

    public static void Send(Component sender, string method)
    {
        Send(new Message(sender, method));
    }

    public static void Send(Component sender, string method, Dictionary<string, object> data)
    {
        Send(new Message(sender, method, data));
    }

    private enum Action { Register, Unregister }

    private class Event
    {
        public Action action;
        public string method;
        public Component component;

        public Event(Action action, string method, Component component)
        {
            this.action = action;
            this.method = method;
            this.component = component;
        }
    }
}

public class Message
{
    public Component sender;
    public string method;
    public Dictionary<string, object> data;

    public Message(Component sender, string method)
    {
        this.sender = sender;
        this.method = method;
        this.data = new Dictionary<string, object>();
    }

    public Message(Component sender, string method, Dictionary<string, object> data)
    {
        this.sender = sender;
        this.method = method;
        this.data = data;
    }
}