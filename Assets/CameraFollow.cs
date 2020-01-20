using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public Transform Target;
    public float offset;
    private void LateUpdate()
    {
        Vector3 newPosition = Target.position+new Vector3(0,offset,0);
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

    }
}