using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DJ : MonoBehaviour
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
        if (PlayerPrefs.GetInt("Jumplim") == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {
            PlayerPrefs.SetFloat("CamSize", 10);
            c.orthographicSize = 10;
            PlayerPrefs.SetInt("Jumplim", 1);
            ball.GetComponent<Control>().jumplim = 1;
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
        t.text = "You got the double jump! Hold down left mouse button and release for a second jump!";

    }

}
