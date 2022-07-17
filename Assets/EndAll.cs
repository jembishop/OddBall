using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAll : MonoBehaviour {
    private Control control;
	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            control.GameOver(false);
        }
        if (collision.gameObject.tag != "Floors")
        {
            collision.transform.DetachChildren();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
