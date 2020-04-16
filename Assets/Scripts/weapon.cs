using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform Bullet;
    public GameObject BulletRed;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(BulletRed, Bullet.position, Bullet.rotation);
    }
}
