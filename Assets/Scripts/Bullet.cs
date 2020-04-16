using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage =10;
    public float speed = 20f;
    public Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = transform.right*speed;  
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        robotGun robot= collision.GetComponent<robotGun>();
        if (robot != null)
        {
            robot.takedamage(damage);
        }
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.takedamage(0.02f);
        }

        Destroy(gameObject);
    }

}
