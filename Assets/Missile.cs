using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    Rigidbody2D rb;
    Rigidbody2D player;
   public  float force;
   public float turn;
    float f;
    public float factor;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        f = rb.angularDrag;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = (rb.position - player.position).normalized;
        Vector2 up = transform.up;
        //rb.angularDrag = f + factor * rb.velocity.magnitude;
        rb.AddTorque(turn*Vector2.SignedAngle(dir, up));
        rb.AddForce(force * up);
    }
}
