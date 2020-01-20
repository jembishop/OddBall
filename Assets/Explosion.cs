using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour

{
    public float radius = 5.0F;
    public float power = 10.0F;
    public float time;
    public float mult;
    public float sttime;
    private bool a;
    public GameObject fireball;
    private SpriteRenderer s;
    Rigidbody2D bomb;

    void Start()
    {
        a = false;
        Invoke("Timer", sttime);
        s = GetComponent<SpriteRenderer>();
        bomb = GetComponent<Rigidbody2D>();
      
    }
    private void Update()
    {
        if (Input.GetButtonDown("Bomb")&&a) {
            Explode();
        }
    }
    public void Explode()
    {
        Vector3 pos = bomb.position;
        Vector2 explosionPos = transform.position;
        GameObject f=Instantiate(fireball,pos,Quaternion.identity);
        print(f.transform.position);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
       
        foreach (Collider2D hit in colliders)
        {
            float x;
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if(rb.tag=="Mech") { x = mult; }
                else { x = 1; }
                Vector2 dir = rb.position - bomb.position;
                if (dir.sqrMagnitude != 0)
                {
                    rb.AddForce(x*power * dir/ ((Mathf.Pow(dir.magnitude,1.5f))));
                }
            }
        }
        Destroy(gameObject);
    }
    void Timer() {
        a = true;
    }
}