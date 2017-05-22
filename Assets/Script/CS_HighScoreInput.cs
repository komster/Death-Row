using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_HighScoreInput : MonoBehaviour {

    public Text player1Letter1;
    public Text player1Letter2;
    public Text player1Letter3;

    public Text player2Letter1;
    public Text player2Letter2;
    public Text player2Letter3;

    public string combinedPlayersEntry;
    public bool goToMainMenu = false;

    public GameObject player1PointerHolder;
    public GameObject player2PointerHolder;

    private int letterNumberPlayer1=1;
    private char currentPlayer1Letter = 'A';
    private int player1CharCode;
    private bool player1Pressing;
    private bool player1Done = false;
    private bool player1UsingOar;

    private int letterNumberPlayer2 = 1;
    private char currentPlayer2Letter = 'A';
    private int player2CharCode;
    private bool player2Pressing;
    public bool player2Done = false;
    private bool player2UsingOar;

    private float timer = 1f;
    private float maxBlinkInterval = 2f;
    private float minBlinkInterval = 0.3f;
    private float blinkInterval = 3f;
    private float time = 10f;

    // Use this for initialization
    void Start ()
    {
        player1Letter1= GameObject.Find("player1Letter1").GetComponent<Text>();
        player1Letter2 = GameObject.Find("player1Letter2").GetComponent<Text>();
        player1Letter3 = GameObject.Find("player1Letter3").GetComponent<Text>();
        player1Letter1.text = currentPlayer1Letter+"";
        player1Letter2.text = currentPlayer1Letter + "";
        player1Letter3.text = currentPlayer1Letter + "";
        player1CharCode = currentPlayer1Letter;

        player2Letter1 = GameObject.Find("player2Letter1").GetComponent<Text>();
        player2Letter2 = GameObject.Find("player2Letter2").GetComponent<Text>();
        player2Letter3 = GameObject.Find("player2Letter3").GetComponent<Text>();
        player2Letter1.text = currentPlayer2Letter + "";
        player2Letter2.text = currentPlayer2Letter + "";
        player2Letter3.text = currentPlayer2Letter + "";
        player2CharCode = currentPlayer2Letter;

        player1PointerHolder = GameObject.Find("Player1PointerHolder");
        player2PointerHolder = GameObject.Find("Player2PointerHolder");
        
    }
	
	//----------------------------UPDATE-------------------------------------------------------------------
	void Update ()
    {
        blinkInterval = minBlinkInterval + timer / time * (maxBlinkInterval);
        
        if (player1Done == false)
        {
            Player1Input();
            Player1PointersBlink();
        }

        if (player2Done == false)
        {
            Player2Input();
            Player2PointersBlink();
        }

        if (player1Done == true)
        {
            foreach (Image ima in player1PointerHolder.GetComponentsInChildren<Image>())
            {
                ima.enabled = false;
            }
        }

        if (player2Done == true)
        {
            foreach (Image ima in player2PointerHolder.GetComponentsInChildren<Image>())
            {
                ima.enabled = false;
            }
        }
        
      

        if (player1Done == true && player2Done == true)
        {
           
            combinedPlayersEntry = player1Letter1.text + player1Letter2.text + player1Letter3.text + " & " + player2Letter1.text + player2Letter2.text + player2Letter3.text;
            goToMainMenu = true;
            
        }
        

    }
   
    //----------------------------------------------PLAYER 1 INPUT-------------------------------------------------------------------------------------------------------
    private void Player1Input()
    {
        if (Input.GetAxis("ControllerP1") >= 0.5 || Input.GetAxis("ControllerP1") <= -0.5)
        {
            player1UsingOar = true;
        }
        if (Input.GetAxis("RightReload") >= 0.5 || Input.GetAxis("RightReload") <= -0.5)
        {
            player1UsingOar = false;
        }

        if (player1UsingOar == true)
        {
            if (Input.GetAxis("ControllerP1") <= 0.5 && Input.GetAxis("ControllerP1") >= -0.5)
            {
                player1Pressing = false;
            }
            if (Input.GetAxis("ControllerP1") >= 0.5)
            {
                ChangeLetterPlayer1(true);
            }
            if (Input.GetAxis("ControllerP1") <= -0.5)
            {
                ChangeLetterPlayer1(false);
            }
        }
        else
        {
            if (Input.GetAxis("RightReload") <= 0.5 && Input.GetAxis("RightReload") >= -0.5)
            {
                player1Pressing = false;
            }
            if (Input.GetAxis("RightReload") >= 0.5)
            {
                ChangeLetterPlayer1(false);
            }
            if (Input.GetAxis("RightReload") <= -0.5)
            {
                ChangeLetterPlayer1(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A))
        {
            LockInletterPlayer1();
        }
        if (letterNumberPlayer1 == 4)
        {
            player1Done = true;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------

    //-----------------------------CHANGE LETTER PLAYER 1--------------------------------------------------------------------------------------------
    private void ChangeLetterPlayer1(bool up)
    {
        if (player1Pressing == false)
        {
            player1Pressing = true;
            if (up == true)
            {
                if (player1CharCode < 90 || player1CharCode > 96 && player1CharCode < 122)
                {
                    player1CharCode++;
                }
                else if (player1CharCode == 90)
                {
                    player1CharCode = 97;
                }
                else if (player1CharCode == 122)
                {
                    player1CharCode = 65;
                }
            }
            else
            {
                if (player1CharCode < 91 && player1CharCode > 65 || player1CharCode > 97 && player1CharCode < 123)
                {
                    player1CharCode--;
                }
                else if (player1CharCode == 65)
                {
                    player1CharCode = 122;
                }
                else if (player1CharCode == 97)
                {
                    player1CharCode = 90;
                }

            }
        }
        switch (letterNumberPlayer1)
        {
            case (1):
              
                    currentPlayer1Letter = System.Convert.ToChar(player1CharCode);
                    player1Letter1.text = currentPlayer1Letter + "";
                    
                break;
            case (2):

                currentPlayer1Letter = System.Convert.ToChar(player1CharCode);
                player1Letter2.text = currentPlayer1Letter + "";
               
                break;
            case (3):

                currentPlayer1Letter = System.Convert.ToChar(player1CharCode);
                player1Letter3.text = currentPlayer1Letter + "";
               
                break;
        }
    }
    //--------------------------------------------------------------------------------------------------------------

    //------------------LOCK IN LETTER PLAYER 1----------------------------------------------------------------------------------------------
     private void LockInletterPlayer1()
    {
        if(letterNumberPlayer1>0&& letterNumberPlayer1 < 5)
        {
            letterNumberPlayer1++;
            player1CharCode = 65;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------PLAYER 1 POINTERS BLINK-----------------------------------------------------------------------------------------------
    private void Player1PointersBlink()
    {
        foreach (Image ima in player1PointerHolder.GetComponentsInChildren<Image>())
        {
            ima.enabled =(Mathf.PingPong(Time.unscaledTime, blinkInterval) > (blinkInterval / 2.0f));
        }
        switch (letterNumberPlayer1)
        {
            case (1):
                player1PointerHolder.transform.localPosition = new Vector3(-70, 0, 0);
                break;
            case (2):
                player1PointerHolder.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case (3):
                player1PointerHolder.transform.localPosition = new Vector3(75, 0, 0);
                break;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------PLAYER 2 INPUT----------------------------------------------------------------------------------------------------------------
    private void Player2Input()
    {
        if (Input.GetAxis("ControllerP2") >= 0.5 || Input.GetAxis("ControllerP2") <= -0.5)
        {
            player2UsingOar = true;
        }
        if (Input.GetAxis("LeftReload") >= 0.5 || Input.GetAxis("LeftReload") <= -0.5)
        {
            player2UsingOar = false;
        }


        if (player1UsingOar == true)
        {
            if (Input.GetAxis("ControllerP2") <= 0.5 && Input.GetAxis("ControllerP2") >= -0.5)
            {
                player2Pressing = false;
            }
            if (Input.GetAxis("ControllerP2") >= 0.5)
            {
                ChangeLetterPlayer2(true);
            }
            if (Input.GetAxis("ControllerP2") <= -0.5)
            {
                ChangeLetterPlayer2(false);
            }
        }
        else
        {
            if (Input.GetAxis("LeftReload") <= 0.5 && Input.GetAxis("LeftReload") >= -0.5)
            {
                player2Pressing = false;
            }
            if (Input.GetAxis("LeftReload") >= 0.5)
            {
                ChangeLetterPlayer2(false);
            }
            if (Input.GetAxis("LeftReload") <= -0.5)
            {
                ChangeLetterPlayer2(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            LockInletterPlayer2();
        }
        if (letterNumberPlayer2 == 4)
        {
            player2Done = true;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------

    //-----------------------------CHANGE LETTER PLAYER 2--------------------------------------------------------------------------------------------
    private void ChangeLetterPlayer2(bool up)
    {
        if (player2Pressing == false)
        {
            player2Pressing = true;
            if (up == true)
            {
                if (player2CharCode < 90 || player2CharCode > 96 && player2CharCode < 122)
                {
                    player2CharCode++;
                }
                else if (player2CharCode == 90)
                {
                    player2CharCode = 97;
                }
                else if (player2CharCode == 122)
                {
                    player2CharCode = 65;
                }
            }
            else
            {
                if (player2CharCode < 91 && player2CharCode > 65 || player2CharCode > 97 && player2CharCode < 123)
                {
                    player2CharCode--;
                }
                else if (player2CharCode == 65)
                {
                    player2CharCode = 122;
                }
                else if (player2CharCode == 97)
                {
                    player2CharCode = 90;
                }

            }
        }
        switch (letterNumberPlayer2)
        {
            case (1):

                currentPlayer2Letter = System.Convert.ToChar(player2CharCode);
                player2Letter1.text = currentPlayer2Letter + "";

                break;
            case (2):

                currentPlayer2Letter = System.Convert.ToChar(player2CharCode);
                player2Letter2.text = currentPlayer2Letter + "";

                break;
            case (3):

                currentPlayer2Letter = System.Convert.ToChar(player2CharCode);
                player2Letter3.text = currentPlayer2Letter + "";

                break;
        }
    }
    //--------------------------------------------------------------------------------------------------------------

    //------------------LOCK IN LETTER PLAYER 2----------------------------------------------------------------------------------------------
    private void LockInletterPlayer2()
    {
        if (letterNumberPlayer2 > 0 && letterNumberPlayer2 < 5)
        {
            letterNumberPlayer2++;
            player2CharCode = 65;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------PLAYER 2 POINTERS BLINK-----------------------------------------------------------------------------------------------
    private void Player2PointersBlink()
    {
        
        foreach (Image ima in player2PointerHolder.GetComponentsInChildren<Image>())
        {
            ima.enabled = (Mathf.PingPong(Time.unscaledTime, blinkInterval) > (blinkInterval / 2.0f));
        }
        switch (letterNumberPlayer2)
        {
            case (1):
                player2PointerHolder.transform.localPosition = new Vector3(-70, 0, 0);
                break;
            case (2):
                player2PointerHolder.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case (3):
                player2PointerHolder.transform.localPosition = new Vector3(75, 0, 0);
                break;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------
}
