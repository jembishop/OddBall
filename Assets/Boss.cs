using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public float upspeed;
    private Rigidbody2D player;
    private Rigidbody2D boss;
    public float speed;
    public float amp;
    public float angspeed;
    Ray2D ray;
    float start;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        boss = GetComponent<Rigidbody2D>();
       
    }
 
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        /*
        boss.MovePosition(pos+amp*Vector2.right * Mathf.Cos(Time.time - start)*speed);
        boss.MoveRotation(Mathf.Sin(Time.time - start) * angspeed);
        Vector2 dir = (pos - player.position).normalized;
        */

        boss.MovePosition(pos+Vector2.up * upspeed*Time.timeScale);

    }
}
