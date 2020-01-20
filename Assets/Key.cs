using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public float speed;
    public GameObject openable;
    public bool respawns=true;
    private Openable a;
    private SpriteRenderer s;
    private Control control;

    public bool keyenabled = true;
    private Collider2D coli;
    // Use this for initialization
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        a = openable.GetComponent<Openable>();
        s = GetComponent<SpriteRenderer>();
        coli = GetComponent<Collider2D>();
        if (PlayerPrefs.GetInt("Newgame")==1){
            PlayerPrefs.SetInt(gameObject.name, 0);

        }
        if (PlayerPrefs.GetInt(gameObject.name) == 1) { Disable();
        }
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arm")&&keyenabled)
        {

            a.Open();
            Disable();

            control.keys.Add(gameObject.GetComponent<Key>());
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Quaternion.Euler(new Vector3(0, speed * Time.timeSinceLevelLoad, 0));
    }
    private void Disable() {
        keyenabled = false;
        s.enabled = false;
        coli.enabled = false;
        PlayerPrefs.SetInt(gameObject.name, 1);
    }

    public void Wake() {
        if (respawns&&!keyenabled)
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
            s.enabled = true;
            coli.enabled = true;
            keyenabled = true;
            a.Close();
            
        }
        
    }
   
}
