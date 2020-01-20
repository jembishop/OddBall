using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public float time;
    public float speed;
    public float velrange;
    public float range;
    public bool enab;
    Rigidbody2D bombrb;
    public float spread;
    public GameObject bomb;
    public GameObject bomb2;
	// Use this for initialization
	void Start () {

        Invoke("Fire",3*Random.value);
	}

    void Fire() {
        if (enab)
        {
            float vel = Random.Range(-velrange, velrange);
            float angle = Random.Range(-range, range);
            GameObject mbomb;
            if (Random.value > spread) { mbomb = bomb; }
            else { mbomb = bomb2; }
            GameObject mybomb = Instantiate(mbomb, transform.position, transform.rotation);
            bombrb = mybomb.GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            bombrb.velocity = (speed + velrange) * dir;
        }
        Invoke("Fire", time/2);
    
        }
	// Update is called once per frame

}
