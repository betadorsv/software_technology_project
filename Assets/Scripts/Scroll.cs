using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sroll : MonoBehaviour
{
    // Start is called before the first frame update

    public Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = player.transform.position.x;
        mat.mainTextureOffset = offset * Time.fixedDeltaTime / 0.42f;
    }
}
