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
    void Start () {
        coins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            playerpos = this.gameObject.transform.position;
            gotHit = true;
            hp--;
            StartCoroutine(damageFeedback());
        }

        if (collision.gameObject.tag == "End")
        {
            ended = true;
            winScreen.gameObject.SetActive(true);
            Debug.Log("jay");
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
}
