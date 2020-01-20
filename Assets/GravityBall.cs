using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityBall : MonoBehaviour {
   public  bool iscol;
    float grav;
    Camera c;
    // Use this for initialization
    void Start () {
        grav = Physics2D.gravity.magnitude;
        c = Camera.main;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        iscol = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        iscol = false;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (iscol)
        {
            Physics2D.gravity = -transform.up * grav;
            c.transform.rotation = transform.rotation;
        }
	}
}
