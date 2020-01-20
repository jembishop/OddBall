using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJPickup : MonoBehaviour {
    public float speed;
    private Control control;
    public bool respawns = true;
    private SpriteRenderer s;


    public bool keyenabled = true;
    private Collider2D coli;
    // Use this for initialization
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        s = GetComponent<SpriteRenderer>();
        coli = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm") && keyenabled)
        {

            control.jumps = control.jumplim ;
           // Disable();

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm") && keyenabled)
        {

            control.jumps = control.jumplim;
            // Disable();

        }
    }
    // Update is called once per frame

    private void Disable()
    {
        keyenabled = false;
        s.enabled = false;
        coli.enabled = false;
    }

    public void Wake()
    {
        if (respawns && !keyenabled)
        {
            s.enabled = true;
            coli.enabled = true;
            keyenabled = true;
            

        }

    }

}
