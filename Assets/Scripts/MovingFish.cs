using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : MonoBehaviour
{
    public float speed = 0.1f, changemoving = -1;
    bool faceright = true;
    public PauseUI pauseui;
    // Start is called before the first frame update
    Vector3 Move;
    void Start()
    {
        Move = this.transform.position;
        pauseui = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseUI>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseui.pause) {
            this.transform.position = this.transform.position;
        }
        if (pauseui.pause == false)
        {
            Move.x += speed;
            this.transform.position = Move;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
        {
            speed *= changemoving;
            Flip();
        };
    }


    private void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

}
