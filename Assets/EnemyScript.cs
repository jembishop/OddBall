using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
    public GameObject enemy;
    public GameObject player,arm;
    public float damage;
    public float maxhealth;
    private Control control;
    public Rigidbody2D rb,enemyrb;
    public float speed;
    public Image healthbar;
    public Canvas c;
    public float health;
    public Vector2 offset;
    public float timer;
	// Use this for initialization
	void Start () {
        rb = player.GetComponent<Rigidbody2D>();
        enemyrb = enemy.GetComponent<Rigidbody2D>();
        control = player.GetComponent<Control>();
        health = maxhealth;
    }
 
   
    public void Timer() {
        enemyrb.gravityScale = 0.3f;
        enemyrb.drag = 0.01f;
    }
    public void Damage(float damage)
    {
      
        if (damage > 10)
        {
            health -= damage;
            healthbar.fillAmount = health / maxhealth;
            
            if (health < 0) { Die(); }
        }
    }
    public void Die() { Destroy(gameObject); }
    // Update is called once per frame
    void Update () {
        c.transform.position = enemyrb.position + offset;
         timer -= Time.deltaTime;
        if (timer < 0) { Timer(); }
        Vector2 dir = enemyrb.position - rb.position;
            enemyrb.AddForce(-dir* speed*enemyrb.mass);
        
	}
}
