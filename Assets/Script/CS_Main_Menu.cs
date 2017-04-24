using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_Main_Menu : MonoBehaviour
{
    public GameObject highScoreHolder;
    public int mainMenuState = 0;

    private List<GameObject> MainMenuList = new List<GameObject>();

    private void Start()
    {
        MainMenuList.Add(GameObject.Find("State0"));
        MainMenuList.Add(GameObject.Find("State1"));
        MainMenuStateManager();
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
