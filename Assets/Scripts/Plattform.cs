using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plattform : MonoBehaviour
{
    Collider2D plattform;
    Transform position;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        plattform = GetComponent<BoxCollider2D>();
        position = GetComponent<Rigidbody2D>().transform;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(position.position.y <= collider.gameObject.transform.position.y)
        {
            plattform.isTrigger = false;
            player.jumps = 0;

        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            plattform.isTrigger = false;
            
        }
    }
}
