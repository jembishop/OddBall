using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    private bool swinging=false;
    public Color mycol;
    Color col;
    public float period;
    SpriteRenderer s;
    void MakeWhite()
    {
        s.color = mycol;
        Invoke("MakeOriginal", period);
    }
    void MakeOriginal()
    {
        s.color = col;
        Invoke("MakeWhite", period);
    }
    // Use this for initialization
    void Start () {

        if (PlayerPrefs.GetInt("Newgame") == 1)
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }

        if (PlayerPrefs.GetInt(gameObject.name) == 1) { Swing(); }
        s = GetComponent<SpriteRenderer>();
        col = s.color;
        rb = GetComponent<Rigidbody2D>();
        MakeWhite();

    }
	public void Swing()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        swinging = true;
    }
    public void Stop()
    {
        rb.rotation = 90;
        rb.angularVelocity = 0;
        swinging = false;
    }
	// Update is called once per frame
	void Update () {
        if (swinging)
        {
            rb.angularVelocity = speed;
        }
	}
}
