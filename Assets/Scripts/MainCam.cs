using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    public float camx, camy;
    public Vector2 velocity;
    public GameObject player;
    public Vector2 minCam,maxCam;
    public bool limitCam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, camx);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, camy);
        transform.position = new Vector3(posX, posY,transform.position.z);
        if (limitCam)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCam.x, maxCam.x),
                Mathf.Clamp(transform.position.y, minCam.y, maxCam.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}
