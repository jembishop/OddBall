using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {
    public float enbulldam=10;
    private float t;
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
   
   
        if (collision.gameObject.name != "Arm")
           
        { Destroy(gameObject);  }
    }
   
}
