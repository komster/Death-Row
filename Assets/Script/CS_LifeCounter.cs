using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_LifeCounter : MonoBehaviour {

    
    private CS_Player player;
    public GameObject counter;
    public GameObject life;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    // Use this for initialization
    void Start ()
    {
        life = GameObject.Find("Life");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
        life4 = GameObject.Find("Life4");
        life5 = GameObject.Find("Life5");
        counter = GameObject.Find("LifeCounter");
        player = GameObject.Find("Player").GetComponent<CS_Player>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //lifeChanger();
	}
    public void lifeChanger()
    {
<<<<<<< HEAD
        if (player.activateLife == true)
        {
            counter.SetActive(true);
            StartCoroutine(counterActive());
            if(player.hp == 4)
            {
                life.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            else if(player.hp == 3)
            {
                life.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            else if (player.hp == 2)
            {
                life.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            else if (player.hp == 1)
            {
                life.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(true);
                life5.SetActive(false);
            }
            else if (player.hp == 0)
            {
                life.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(true);
            }
        }
        else
        {
            counter.SetActive(false);
        }
=======
        //if(stage.enableLife == true)
        //{
        //    counter.SetActive(true);
        //    if(player.hp == 4)
        //    {
        //        life.SetActive(true);
        //        life2.SetActive(false);
        //        life3.SetActive(false);
        //        life4.SetActive(false);
        //        life5.SetActive(false);
        //    }
        //    else if(player.hp == 3)
        //    {
        //        life.SetActive(false);
        //        life2.SetActive(true);
        //        life3.SetActive(false);
        //        life4.SetActive(false);
        //        life5.SetActive(false);
        //    }
        //    else if (player.hp == 2)
        //    {
        //        life.SetActive(false);
        //        life2.SetActive(false);
        //        life3.SetActive(true);
        //        life4.SetActive(false);
        //        life5.SetActive(false);
        //    }
        //    else if (player.hp == 1)
        //    {
        //        life.SetActive(false);
        //        life2.SetActive(false);
        //        life3.SetActive(false);
        //        life4.SetActive(true);
        //        life5.SetActive(false);
        //    }
        //    else if (player.hp == 0)
        //    {
        //        life.SetActive(false);
        //        life2.SetActive(false);
        //        life3.SetActive(false);
        //        life4.SetActive(false);
        //        life5.SetActive(true);
        //    }
        //}
        //else
        //{
        //    counter.SetActive(false);
        //}
>>>>>>> origin/master
        
    }
    public IEnumerator counterActive()
    {
        yield return new WaitForSeconds(4f);
        player.activateLife = false;
    }
}
