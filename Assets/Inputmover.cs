using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmover : MonoBehaviour
{
    // Start is called before the first frame update
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
        {
            movement += Vector3.right;
        }
        if (horizontal < 0)
        {
            movement -= Vector3.right;
        }
        if (vertical > 0)
        {
            movement += Vector3.up;
        }
        if (vertical < 0)
        {
            movement -= Vector3.up;
        }

        movement.Normalize();

        transform.position += movement * Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire button clicked!");
        }
    }
}
