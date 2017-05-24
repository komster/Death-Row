using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_GTTIPrompt : MonoBehaviour {


    public List<Text> prompt;
    
    // Use this for initialization
    void Start ()
    {

        foreach (Transform child in this.transform)
        {
            if (child.tag == ("Prompt"))
            {

                prompt.Add(child.GetComponent<Text>());

            }

        }
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator ShowPrompt()
    {
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = true;
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < prompt.Count; i++)
        {
            prompt[i].GetComponent<Text>().enabled = false;
        }
    }
}
