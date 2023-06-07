using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private SpriteRenderer weapon;
    public Animator Animator;
    //[SerializeField] private ParticleSystem ShootParticle;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (rotZ >= 90 || rotZ <= -90)
        {
            weapon.flipY = true;
        }

        else
        {
            weapon.flipY = false;
        }

        if (!canFire)
        {
            timer += Time.deltaTime;

            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Animator.SetTrigger("Flash");
            AudioManager.PlaySFX("M4");
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Animator.SetTrigger("NoFlash");
        }
    }
}
