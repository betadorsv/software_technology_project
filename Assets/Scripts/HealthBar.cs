using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    Transform bar;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        bar = gameObject.GetComponent<Transform>();
        

    }

    private void Update()
    {
        HPBar(player.PlayerHealth);
        
    }
    public void HPBar(float sizebar)
    {
        bar.localScale = new Vector3(sizebar, 0.428f);
    }
    public void Setcolor(Color color)
    {
        bar.Find("healthbar").GetComponent<SpriteRenderer>().color = color;
    }
}
