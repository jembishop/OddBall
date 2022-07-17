using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hook : MonoBehaviour
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
        if (PlayerPrefs.GetInt("GrappleEnabled") == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {
            PlayerPrefs.SetFloat("CamSize", 12);
            c.orthographicSize = 12;
            PlayerPrefs.SetInt("GrappleEnabled", 1);
            ball.GetComponent<Control>().grappleenabled = true;
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

        t.text = "You got the grappling hook! Press the right mouse button or 'q' to attach to a green or white surface. Be careful though your rockets are disabled when you grapple!";

    }

}
