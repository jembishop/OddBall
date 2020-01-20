using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {
    private DistanceJoint2D d1;
    private LineRenderer l1;
   
    // Use this for initialization
    void Start () {
        d1 = GetComponent<DistanceJoint2D>();
        l1= GetComponent<LineRenderer>();
       
    }
	
	// Update is called once per frame
	void Update () {
        
            Vector3 k = d1.connectedAnchor;
            Vector3 j = transform.TransformPoint( d1.anchor);
            Vector3[] m = new Vector3[2];
            m[0] = k;
            m[1] = j;
            l1.SetPositions(m);
        
	}
}
