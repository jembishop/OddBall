using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour {
    public GameObject ball;
    private Control control;
    void Start()
    {
        control = ball.GetComponent<Control>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        control.jumps = control.jumplim;
        control.touching = true;
        control.t = control.djtime;
     

    }
   
   

    void OnCollisionExit2D(Collision2D col)
    {
  
        control.touching = false;

    }
}
