using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {
    float a;
	// Use this for initialization
	void Start () {
        StartCoroutine(Example());
	}

    // Update is called once per frame
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

