using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rocket : MonoBehaviour {
    public float speed;
    public Camera c;
    public Text t;
    public GameObject b;
    public Image i;
    // Use this for initialization
    void Start () {
        c = Camera.main;
        if (PlayerPrefs.GetInt("RocketEnabled")==1) {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")
        {
            PlayerPrefs.SetFloat("CamSize", 9);
            c.orthographicSize = 9;
            PlayerPrefs.SetInt("RocketEnabled", 1);
            print(PlayerPrefs.GetInt("RocketEnabled"));
            ball.GetComponent<Control>().rocketenabled = true;
            Destroy(gameObject);
            Showstuff();
        }
    }
    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(0, speed*Time.timeSinceLevelLoad, 0));
	}

    void Showstuff(){
        i.enabled = true;
        Time.timeScale = 0;
        b.SetActive(true);

        t.text = "You got the rocket boosters! Press 'a' and 'd' or 'left' and 'right' to move!";

    }

}
