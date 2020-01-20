using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    public float dis;
    public Vector2 dir;
    private Vector2 j;
    private Control c;
    public Color mycol;
    public float period;
    float x;
    Color col;
    SpriteRenderer s;
    public bool opened=false;
    public bool closed = false;
    void Stop() { opened = false; closed = false; }
    // Use this for initialization
    void MakeWhite() {
        s.color = mycol;
        Invoke("MakeOriginal", period); 
    }
    void MakeOriginal()
    {
        s.color = col;
        Invoke("MakeWhite", period);
    }
    void Start () {
        s = GetComponent<SpriteRenderer>();
        c = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>(); 
        rb = GetComponent<Rigidbody2D>();
         j = rb.position;
        col = s.color;
        MakeWhite();
        dir = dir.normalized;
    }
    public void Open() { opened = true; }
    public void Close() { closed=true; }
	// Update is called once per frame
	void FixedUpdate () {
        
            if (c.timestopnow)
            { x = speed / c.timeslow; }
            else { x = speed; }

            Vector2 l = rb.position;
            if (opened && !closed)
            {
                rb.MovePosition(l + x * dir);
                if ((l-j).magnitude>dis)
                {
                    Stop();
                }

            }
            if (closed)
            {
                rb.MovePosition(l - dir);

            if (Vector2.Dot((l - j),dir) < 0) 
                {
                    Stop();
                }


            }
        
    }
}
