using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Arm" && collision.gameObject.tag != "Bullet")
        { Invoke("Des",0.5f); }
    }
    void Des() { Destroy(gameObject); }
}
