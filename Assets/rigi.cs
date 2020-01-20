using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigi : MonoBehaviour {
    private Rigidbody2D rb;
   
   
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        float rot = rb.rotation;
        Vector2 pos = rb.position;
        if (PlayerPrefs.GetInt("Newgame")!=1)
        {
            rb.position = new Vector2(PlayerPrefs.GetFloat(gameObject.name + "x"), PlayerPrefs.GetFloat(gameObject.name + "y"));

            rb.rotation = PlayerPrefs.GetFloat(gameObject.name + "rot");
        }
        else {
            PlayerPrefs.SetFloat(gameObject.name + "y", pos.y);
            PlayerPrefs.SetFloat(gameObject.name + "x", pos.x);
            PlayerPrefs.SetFloat(gameObject.name + "rot", rot);
        }

    }
    public void Wake()
    {
        if (rb != null)
        {
            rb.position = new Vector2(PlayerPrefs.GetFloat(gameObject.name + "x"), PlayerPrefs.GetFloat(gameObject.name + "y"));
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.rotation = PlayerPrefs.GetFloat(gameObject.name + "rot");
        }
    }
 
    public void Checkpoint()
    {
        if (rb != null)
        { Vector2 pos = rb.position;
            float rot = rb.rotation;
            PlayerPrefs.SetFloat(gameObject.name + "y",pos.y);
            PlayerPrefs.SetFloat(gameObject.name + "x", pos.x);
            PlayerPrefs.SetFloat(gameObject.name + "rot", rot);

        }
    }
}
