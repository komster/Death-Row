using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CannonBallPlayer : MonoBehaviour {

    public float range= 1.5f;

    void Start()
    {

    }

    void Update()
    {
        range -= Time.deltaTime;
        if (range <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
