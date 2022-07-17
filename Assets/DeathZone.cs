using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
    Control control;
    public float buildup;
    public float warning;
    public float death;
    public Color col;
    public Color col1;
    public Color col2;
    public float offset;
    SpriteRenderer s;
    bool active;
	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        s = GetComponent<SpriteRenderer>();
        Invoke("Buildup", offset);
        s.color = col;
        active = false;
	}
    void Buildup() {
        s.color = col;
        Invoke("Warning", buildup);
        active = false;
    }
    void Warning() {
        s.color = col1;
        Invoke("Death", warning);
 
    }
    void Death() {
        s.color = col2;
        active = true;
        Invoke("Buildup", death);
      
       
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player" && active) {
            control.GameOver(true);
        }
    }
}
