using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotplat : MonoBehaviour {
   private Rigidbody2D rb;
    public float vel;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = vel;
    }
}
