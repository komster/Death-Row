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
    public List<Transform> damagePoints = new List<Transform>();

    void Start () {
        coins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Damage")
            {
                damagePoints.Add(child);
                child.GetComponent<ParticleSystem>().Stop();
            }
        }
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CannonBallEnemy")
        {
            Destroy(collision.gameObject);
            playerpos = this.gameObject.transform.position;
            gotHit = true;
            activateLife = true;
            hp--;
            ActivateDamagePoints();
            //impactHit.Play();
            StartCoroutine(damageFeedback());
        }
        if (collision.gameObject.tag == "End")
        {
            ended = true;
            winScreen.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        if (hp <= 0)
        {
            death();
        }
    }

    public void death()
    {
        dead = true;

        gameover.gameObject.SetActive(true);
        //StartCoroutine(onDeath());
        Time.timeScale = 0;
    }
    private IEnumerator onDeath()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
    public IEnumerator damageFeedback()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.7f);
        rend.material.color = Color.white;
        
    }
    private void ActivateDamagePoints()
    {
        for (int i = 0; i < hp - 1; i++)
        {
            damagePoints[i].GetComponent<ParticleSystem>().Play();
        }
    }
}
