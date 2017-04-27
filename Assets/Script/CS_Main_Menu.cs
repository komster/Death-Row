using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Main_Menu : MonoBehaviour
{
    public GameObject highScoreHolder;
    public int mainMenuState = 0;
    private bool player1Ready = false;
    private bool player2Ready = false;
    private List<GameObject> MainMenuList = new List<GameObject>();

    private void Start()
    {
        MainMenuList.Add(GameObject.Find("State0"));
        MainMenuList.Add(GameObject.Find("State1"));
        MainMenuStateManager();

        player1Ready = false;
        player2Ready = false;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            player1Ready = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
             player2Ready = true;
        }

        if (player1Ready == true && player2Ready == true)
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowHighScore()
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

    }
}
