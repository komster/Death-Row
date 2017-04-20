using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour {

    Rigidbody2D rb;
    public float MovSpeed = 100.0f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, 1, 0);
            rb.velocity = transform.up * MovSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back, 1, 0);
            rb.velocity = transform.up * MovSpeed;
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0,0);
        }

    }
}
