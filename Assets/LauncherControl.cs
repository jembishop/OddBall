using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControl : MonoBehaviour {
    public bool enabler;
    public Launcher[] launchers;
	// Use this for initialization
	void Start () {
     

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(Launcher l in launchers) {
            l.enab = enabler;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
