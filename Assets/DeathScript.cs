using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {
    public GameObject player;
    private Control control;
    private void Start()
    {
        control = player.GetComponent<Control>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player) {
            control.GameOver(true);
        }
    }

}
