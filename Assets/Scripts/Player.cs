using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed = 3, jumpPow = 220f;
    public bool death = false,shoot=false;
    public bool grounded = true,faceright=true,doublejump=false;
    [SerializeField] public float PlayerHealth = 0.43f;
    public float MaxHealth= 0.43f;
    public int score;
    public Text scoretext;
    public Rigidbody2D rd2d;
    public Animator amin;
    public SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        setscoretext();
        rd2d = gameObject.GetComponent<Rigidbody2D>();
        amin = gameObject.GetComponent<Animator>();
        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        amin.SetBool("Grounded",grounded);
        amin.SetFloat("Speed", Mathf.Abs(rd2d.velocity.x));
        amin.SetBool("Death", death);


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
               
                grounded = false;
                doublejump = true;
                rd2d.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump= !doublejump;
                    rd2d.velocity = new Vector2(rd2d.velocity.x, 0);
                    rd2d.AddForce(Vector2.up * jumpPow *0.7f);
                }
            }
            
        }
       
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rd2d.AddForce((Vector2.right) * speed * h);
        if (rd2d.velocity.x > maxSpeed)
        {
            rd2d.velocity = new Vector2(maxSpeed, rd2d.velocity.y);
        }
        if (rd2d.velocity.x < -maxSpeed)
        {
            rd2d.velocity = new Vector2(-maxSpeed, rd2d.velocity.y);
        }
        if (h > 0 && !faceright)
        {
            Flip();
        }
        if (h < 0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            rd2d.velocity = new Vector2(rd2d.velocity.x * 0.7f, rd2d.velocity.y);
        }

        if (PlayerHealth <= 0)
        {
            Death();
        }
    }

    private void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }

    public void takedamage(float damage)
    {
        
        PlayerHealth -= damage;
        StartCoroutine(changeColor());
        if (PlayerHealth <= 0)
        {
            Death();
        }
      
    }
    IEnumerator changeColor() {
        render.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.05f);
        render.color = new Color(255, 255, 255);

    }
    /*   public void matmau()
       {
           if (PlayerHealth >= 0.1f)
           {
               PlayerHealth = PlayerHealth-  0.1f;
               healthbar.HPBar(PlayerHealth);

               if (PlayerHealth < .3f)
               {
                   if ((PlayerHealth * 100f) % 3 == 0)
                   {
                       healthbar.Setcolor(Color.white);
                   }
                   else
                   {
                       healthbar.Setcolor(Color.red);
                   }

               }
           }
       }*/
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {
            score += 1;
            col.gameObject.SetActive(false);
            setscoretext();
        }
    }
    void setscoretext()
    {
        scoretext.text =  score.ToString();
    }
}
