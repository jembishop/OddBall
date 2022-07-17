﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeStop : MonoBehaviour
{
    public float speed;
    public Camera c;
    Text t;
    public GameObject b;
    Image i;
    // Use this for initialization
    void Start()
    {
        i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Image>();
        t = GameObject.FindGameObjectWithTag("InfoText").GetComponent<Text>();
        c = Camera.main;
        if (PlayerPrefs.GetInt("TimestopEnabled") == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {
   
            PlayerPrefs.SetInt("TimestopEnabled", 1);
            ball.GetComponent<Control>().timestopenabled = true;
            Destroy(gameObject);
            Showstuff();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, speed * Time.timeSinceLevelLoad, 0));
    }

    void Showstuff()
    {
        i.enabled = true;
        Time.timeScale = 0;
        b.SetActive(true);

        t.text = "You got the stopwatch! Press 'w' to slow down time.";

    }

}
