using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movplatform : MonoBehaviour {
    private Rigidbody2D rb;
    public float freq;
    public float mag;
    public float phase;
    private Vector2 pos;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        phase = phase  * Mathf.PI / 180;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity =mag*Mathf.Sin(freq * Time.timeSinceLevelLoad+phase)*freq*transform.up;
	}
}
