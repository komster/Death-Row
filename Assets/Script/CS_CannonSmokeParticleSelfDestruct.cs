using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CannonSmokeParticleSelfDestruct : MonoBehaviour {
    private ParticleSystem ps;


    void Start()
    {
        ps = this.gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if (ps == true)
        {
            if (!ps.IsAlive())
            {
                Destroy(this.gameObject);
            }
        }
    }
}