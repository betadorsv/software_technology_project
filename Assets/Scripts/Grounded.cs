using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded =false;

    }
}
