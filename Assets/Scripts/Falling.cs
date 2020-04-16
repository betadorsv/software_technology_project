using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{


    public Rigidbody2D rd;
    public float delaytime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(falling());
        }
        
    }

    IEnumerator falling()
    {
        yield return new WaitForSeconds(delaytime);
        rd.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
  
}
