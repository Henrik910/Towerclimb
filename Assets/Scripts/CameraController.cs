using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     Player player;
     Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        transform.position = pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < player.rigidbody.position.y)
        {
        pos.y = player.rigidbody.position.y;
        transform.position = pos;
        }
    }
}
