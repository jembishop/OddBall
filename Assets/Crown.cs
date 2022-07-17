﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Crown : MonoBehaviour {
    Text t;
    public GameObject b;
    Image i;
    public float speed;
    void Start()
    {
        i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Image>();
        t = GameObject.FindGameObjectWithTag("InfoText").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {

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
        float time = PlayerPrefs.GetFloat("Time") + Time.timeSinceLevelLoad;
        TimeSpan ti = TimeSpan.FromSeconds(time);
        int deaths = PlayerPrefs.GetInt("Deaths");
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                        ti.Hours,
                        ti.Minutes,
                        ti.Seconds,
                        ti.Milliseconds);

        t.text = String.Format("Well Done! You beat the game in  {0}  with  {1}  deaths.",
                               answer,deaths);
        PlayerPrefs.SetInt("Fresh", 0);
      
    }

}


