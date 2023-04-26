using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamera : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPostion = transform.position;

        newPostion.y = transform.position.y;

        transform.position = newPostion;
    }
}
