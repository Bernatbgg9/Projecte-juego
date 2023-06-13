using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private SpriteRenderer weaponRenderer;
    public Animator Animator;
    public GameObject m4;
    public GameObject pistol;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponRenderer = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (rotZ >= 90 || rotZ <= -90)
        {
            weaponRenderer.flipY = true;
        }
        else
        {
            weaponRenderer.flipY = false;
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

            if (m4.activeInHierarchy)
            {
                AudioManager.PlaySFX("M4");
            }

            if (pistol.activeInHierarchy)
            {
                AudioManager.PlaySFX("Pistol");
            }
            
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Animator.SetTrigger("NoFlash");
        }
    }

    public void ChangeWeapon()
    {
        m4.SetActive(false);
        pistol.SetActive(true);
        weaponRenderer = GameObject.FindGameObjectWithTag("Pistol").GetComponent<SpriteRenderer>();
    }
}
