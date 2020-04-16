using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotGun : MonoBehaviour
{
   
    public float health =10000f;
    public Rigidbody2D rd;
    public bool faceright,awake=false;
    public float awakerange, bullettime, shootinterval;
    public float distance;
    [SerializeField] public float possitionUp;
    [SerializeField] public float possitionDown;
    public Transform player;
    public Transform robot;
    public Transform Bullet;
    public GameObject BulletRed;


    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        
    }


    private void Update()
    {
        if(player.transform.position.x>transform.position.x&&faceright)
        {
            Flip();
        }
        if (player.transform.position.x < transform.position.x &&!faceright)
        {
            Flip();
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x)<=awakerange)
        {
            transform.position = new Vector2(transform.position.x, possitionUp);
            Attack();
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > awakerange)
        {
            transform.position = new Vector2(transform.position.x, possitionDown);
            awake = false;
        }
    }
    
    public void takedamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            die();
        }
    }
    public void Attack()
    {
        bullettime += Time.deltaTime;
        {
            if (bullettime >= shootinterval)
            {
                shoot();
                bullettime = 0;
            }
        }
    }
    private void die()
    {
        Destroy(gameObject);
    }

    private void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }
    // Update is called once per frame
    private void shoot()
    {
        Instantiate(BulletRed, Bullet.position, Bullet.rotation);
    }
}
