using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{
    public float speed;
    public Camera c;
    public Text t;
    public GameObject b;
    public Image i;
    // Use this for initialization
    void Start()
    {
        c = Camera.main;
        if (PlayerPrefs.GetInt("BombsEnabled") == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {
            PlayerPrefs.SetFloat("CamSize", 11);
            c.orthographicSize = 11;
            PlayerPrefs.SetInt("BombsEnabled", 1);
            ball.GetComponent<Control>().bombsenabled = true;
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

        t.text = "You got the bombs! Hold 's' and release to launch a bomb, then press 's' again to detonate. Fire a well timed bomb and jump for a bomb jump!";

    }

}
