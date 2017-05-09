using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Player : MonoBehaviour {

    public bool dead = false;
    public int hp;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
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
        StartCoroutine(onDeath());
    }
    private IEnumerator onDeath()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
