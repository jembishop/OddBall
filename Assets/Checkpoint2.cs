using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour {
    private Control control;
	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            control.deathmode = true;
            PlayerPrefs.SetString("Checkpoint", gameObject.name);
            

        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
