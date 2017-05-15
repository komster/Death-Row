using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DroppedCoin : MonoBehaviour {

    public SpriteRenderer spriteRend;
    public float timeValue = 10f;
    private float maxBlinkTime = 1.2f;
    private float minBlinkTime = 0.2f;
    private float blinkTime = 3f;
    private float time = 10f;
	// Use this for initialization
	void Start () {
        spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        
	}

    // Update is called once per frame
    void Update()
    {
        blinkTime = minBlinkTime + timeValue / time * (maxBlinkTime - minBlinkTime);
        timeValue -= Time.deltaTime;
        if(timeValue < 4f)
        {
            spriteRend.enabled = Mathf.PingPong(Time.time, blinkTime) > (blinkTime / 2.0f);
        }
        if(timeValue<=0)
        {
            Destroy(this.gameObject);
        }

    }
    
}
