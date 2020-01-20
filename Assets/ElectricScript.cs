using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricScript : MonoBehaviour {
    private GameObject ball, arm;
    public float dam;
    private Control control;
    // Use this for initialization
    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        arm = GameObject.FindGameObjectWithTag("Arm");
        control = ball.GetComponent<Control>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball || collision.gameObject == arm)
        {
            control.GameOver();
        }
    }

    // Update is called once per frame
}
