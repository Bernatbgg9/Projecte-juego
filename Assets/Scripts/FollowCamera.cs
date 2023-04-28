using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -1);
    }
}
