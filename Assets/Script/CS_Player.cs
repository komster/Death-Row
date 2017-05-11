using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CS_Player : MonoBehaviour {
    public CS_Gamemanager coins;
    public bool dead = false;
    public int hp = 4;
    public Transform gameover;
    public Vector3 playerpos;
    public bool gotHit = false;
    void Start () {
        coins = GameObject.Find("GameManager").GetComponent<CS_Gamemanager>();
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
        }

        if (collision.gameObject.tag == "End")
        {
            Debug.Log("jay");
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
}
