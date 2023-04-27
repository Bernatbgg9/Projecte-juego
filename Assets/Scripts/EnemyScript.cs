using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform objetivo; // a qui ha de perseguir l'enemic
    public float enemySpeed;

    public bool esDerecha;
    public bool esArriba;

    public float contadorT; // fara la conta enrrere dels 4s (4, 3, 2, 1)
    public float contadorT2;
    public float tiempoParaCambiar = 2f; // tardara 4 segons en cambiar de direccio

    public bool debePerseguir;
    public float distancia; //la distancia entre tu i l'objetivo
    public float distanciaAbsoluta;


    // Start: l'ordinador llegeix el codi nomes un cop
    void Start()
    {
        contadorT = tiempoParaCambiar;
        contadorT2 = tiempoParaCambiar;
    }

    // Update: l'ordinador llegeix el codi de dins tot el rato
    void Update()
    {

        if(esDerecha == true)
        {
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }
        if (esDerecha == false)
        {
            transform.position += Vector3.left * enemySpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

        }
        if (esArriba == true)
        {
            transform.position += Vector3.up * enemySpeed * Time.deltaTime;
         
        }
        if (esArriba == false)
        {
            transform.position += Vector3.down * enemySpeed * Time.deltaTime;
            
        }

        contadorT -= Time.deltaTime;
        contadorT2 -= Time.deltaTime;


        if(contadorT <= 0)
        {
            contadorT = tiempoParaCambiar;
            esDerecha = !esDerecha;
        }
        if (contadorT2 <= 0)
        {
            contadorT2 = tiempoParaCambiar;
            esArriba = !esArriba;
        }

        distancia = objetivo.position.x - transform.position.x;
        distanciaAbsoluta = Mathf.Abs(distancia);

        if (debePerseguir == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, enemySpeed * Time.deltaTime);

            
        }
        if (distancia > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        if (distancia < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }

        if (distanciaAbsoluta < 3)
        {
            debePerseguir = true;
        }
        else { debePerseguir = false; }

    }


}
