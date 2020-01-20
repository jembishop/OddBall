using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public float time;
    SpriteRenderer s;
    public float fade;
	// Use this for initialization
	void Start () {
        Invoke("Des", time);
        s = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Color tmp = s.color;
        tmp.a = tmp.a * fade*Mathf.Exp(-Time.timeScale/10);
        s.color = tmp;
	}
    void Des() {
        Destroy(gameObject);
    }
}
