using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CS_Player : MonoBehaviour {
    public Renderer rend;
    public CS_Gamemanager coins;
    public bool dead = false;
    public int hp = 4;
    public Transform gameover;
    public Transform winScreen;
    public Vector3 playerpos;
    public bool gotHit = false;
    public bool ended = false;
    public bool activateLife = false;
    public AudioSource impactHit;
    public AudioSource onFire;
    public List<Transform> damagePoints = new List<Transform>();
    public GameObject highScoreInput;
    private int whichDamagePoint=0;

    public Animator deathAnimation;

    public GameObject[] playerSprites;

    void Start () {

        coins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        whichDamagePoint = 0;
        CS_Notify.Register(this, "EndGame");
        deathAnimation = GetComponent<Animator>();

        foreach (Transform child in this.transform)
        {
            if (child.tag == "Damage")
            {
                damagePoints.Add(child);
                child.GetComponent<ParticleSystem>().Stop();
            }
        }
        highScoreInput = GameObject.Find("HighScoreInput");
        highScoreInput.SetActive(false);
        
    }
	
	void Update () {


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CannonBallEnemy")
        {
            
            playerpos = this.gameObject.transform.position;
            gotHit = true;
            activateLife = true;
            ActivateDamagePoints();
            hp--;
            impactHit.Play();
            StartCoroutine(damageFeedback());
            
        }
        if (collision.gameObject.tag == "End")
        {
            ended = true;
            coins.CalculateFinalScore();
            CS_Notify.Send(this,"ZoomOut");
       
        }
        if (hp <= 0)
        {
            death();
        }
    }

    public void death()
    {

        dead = true;
        CS_Notify.Send(this,"StopMoving");
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        CS_Player_Movment movment = GetComponent<CS_Player_Movment>();
        movment.enabled = false;
        CS_Player_Cannons cannons = GetComponent<CS_Player_Cannons>();
        cannons.enabled = false;

        for (int inde = 0; inde < playerSprites.Length; inde++)
        {
            playerSprites[inde].gameObject.SetActive(false);
        }
        deathAnimation.enabled = true;
        coins.CalculateFinalScore();

        StartCoroutine(onDeath());



    }

    private IEnumerator onDeath()
    {
        yield return new WaitForSeconds(1.5f);
        highScoreInput.SetActive(true);
        gameover.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public IEnumerator damageFeedback()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.7f);
        rend.material.color = Color.white;
        
    }
    private void ActivateDamagePoints()
    {

        if (hp > 1)
        {
            damagePoints[whichDamagePoint].GetComponent<ParticleSystem>().Play();
            
            whichDamagePoint++;
            onFire.Play();
        }
    }

    public void EndGame()
    {
        highScoreInput.SetActive(true);
        winScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
