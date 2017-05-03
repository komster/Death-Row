using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Main_Menu : MonoBehaviour
{
    public Text highscoreText;
    //public GameObject highScoreHolder;
    //public int mainMenuState = 0;
    public GameObject p1PressButton;
    public GameObject p2PressButton;
    public GameObject p1Ready;
    public GameObject p2Ready;
    private bool player1Ready = false;
    private bool player2Ready = false;
    private bool finished = true;

    private float timer = 1f;
    private float maxBlinkInterval = 2f;
    private float minBlinkInterval = 0.3f;
    private float blinkInterval = 3f;
    private float time = 10f;
    //private List<GameObject> MainMenuList = new List<GameObject>();

    private void Start()
    {
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        /*  MainMenuList.Add(GameObject.Find("State0"));
          MainMenuList.Add(GameObject.Find("State1"));
          MainMenuStateManager();*/
        p1PressButton = GameObject.Find("Player1PressTheButton");
        p2PressButton = GameObject.Find("Player2PressTheButton");
        p1Ready = GameObject.Find("Player1Ready");
        p2Ready = GameObject.Find("Player2Ready");
        p1Ready.SetActive(false);
        p2Ready.SetActive(false);
        player1Ready = false;
        player2Ready = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            player1Ready = true;
            p1PressButton.SetActive(false);
            p1Ready.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
             player2Ready = true;
             p2PressButton.SetActive(false);
             p2Ready.SetActive(true);
        }

        if (player1Ready == true && player2Ready == true)
        {
            StartCoroutine(BothPlayersReady());
        }


        blinkInterval = minBlinkInterval + timer / time * (maxBlinkInterval);

        if (player1Ready == false)
        {
            p1PressButton.SetActive(Mathf.PingPong(Time.time, blinkInterval) > (blinkInterval / 2.0f));
        }
        if (player2Ready == false)
        {
            p2PressButton.SetActive(Mathf.PingPong(Time.time, blinkInterval) > (blinkInterval / 2.0f));
        }


    }

    private IEnumerator BothPlayersReady()
    {
        yield return new WaitForSeconds(2);
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

   
    /*public void ShowHighScore()
    {
        mainMenuState = 1;
        MainMenuStateManager();

    }
    public void GoBackToMainMenu()
    {
        mainMenuState = 0;
        MainMenuStateManager();
    }

    private void MainMenuStateManager()
    {
        foreach (GameObject obj in MainMenuList)
        {
            obj.SetActive(false);
        }
        MainMenuList[mainMenuState].SetActive(true);

    }*/
}
