using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOnRope : MonoBehaviour {
    DistanceJoint2D d;
	// Use this for initialization
	void Start () {
        d = GetComponent<DistanceJoint2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floors") {
            d.enabled = false;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
