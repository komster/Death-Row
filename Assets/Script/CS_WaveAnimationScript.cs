using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_WaveAnimationScript : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.Play("Anim_WaveAnimation", 0, Random.Range(0.0f, 5.0f));
    }
}
