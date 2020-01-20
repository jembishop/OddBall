using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Floors")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = -rb.gravityScale;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Floors")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = -rb.gravityScale;
        }
    }
    // Update is called once per frame

}
