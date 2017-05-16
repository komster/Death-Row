using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PowerUp : MonoBehaviour {

    public int powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (powerUp == 1)
            {
                CS_Notify.Send(this, "MovementUpgrade");
            }
            if (powerUp == 2)
            {
                CS_Notify.Send(this, "CannonUpgrad");
            }
            if (powerUp == 3)
            {
                CS_Notify.Send(this, "BiggerCoinsTrue");
            }
            if (powerUp == 4)
            {
                CS_Notify.Send(this, "ShotCoinsTrue");
            }

            Destroy(this.gameObject);
        }

    }
}
