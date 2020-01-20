using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum2 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool swinging = false;
    private float init;
    public float amp;
    public float starttime;

    // Use this for initialization
    void Start()

    {
        if (PlayerPrefs.GetInt("Newgame") == 1) {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }

        if (PlayerPrefs.GetInt(gameObject.name) == 1) { Swing(); }
        rb = GetComponent<Rigidbody2D>();
        init = rb.rotation;


    }
    public void Swing()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        swinging = true ;
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging)
        {
           rb.angularVelocity=amp * Mathf.Sin(speed*(Time.time-starttime));
            
        }
    }
}
