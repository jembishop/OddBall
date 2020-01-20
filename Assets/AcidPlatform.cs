using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPlatform : MonoBehaviour {
    private GameObject ball;
    public float dam;
    private Control control;
    // Use this for initialization
    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
       
        control = ball.GetComponent<Control>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball)
        {
            control.GameOver();
        }
    }

    // Update is called once per frame

}
