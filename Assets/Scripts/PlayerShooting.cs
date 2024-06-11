using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject iceballPrefab;
    public Transform firePoint;
    public Transform icePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootFireball();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShootIceball();
        }
    }

    void ShootFireball()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootIceball()
    {
        Instantiate(iceballPrefab, icePoint.position, icePoint.rotation);
    }
}