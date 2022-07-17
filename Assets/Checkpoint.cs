using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private Control control;
    public bool saver=false;
    public int id;
    public Color c1;
   private SpriteRenderer s;
    public Color c2;
    private GameObject p;
    private void Start()
    {
         p = GameObject.FindGameObjectWithTag("Player");
        control = p.GetComponent<Control>();
        s = GetComponent<SpriteRenderer>();
        s.color = c1;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Newgame", 0);
            if (id > PlayerPrefs.GetInt("CheckpointID") || (id >= PlayerPrefs.GetInt("CheckpointID") && saver))
            {
                foreach (rigi i in (Object.FindObjectsOfType<rigi>()))
                {
                    i.Checkpoint();
                }
            }

            PlayerPrefs.SetString("Checkpoint", gameObject.name);
            s.color = c2;
            if (PlayerPrefs.GetInt("CheckpointID") < id){
                control.keys = new List<Key>() { };
                control.keys2 = new List<Key2>() { };
                control.keys3 = new List<key3>() { };
            }
            PlayerPrefs.SetInt("CheckpointID", id);


        }
        
        
    }

}
