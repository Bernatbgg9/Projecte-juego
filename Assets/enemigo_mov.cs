using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_mov : MonoBehaviour
{


    public float speed;

    public bool esDerecha;

    public float contadorT;
    public float tiempoParaCambiar;

    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;  
    }

    // Update is called once per frame
    void Update()
    {
       if (esDerecha == true)
       {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //transform.localScale = new Vector3(-2, 2, 2);
       }

        if (esDerecha == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            
            //transform.localScale = new Vector3(2, 2, 2);
        }

        contadorT -= Time.deltaTime;


        if (contadorT <= 0)
        {
            contadorT = tiempoParaCambiar;
           // transform.localScale = new Vector3(1.0f * -1, 1.0f, 1.0f);
            esDerecha = !esDerecha;
             
        }



    }
}
