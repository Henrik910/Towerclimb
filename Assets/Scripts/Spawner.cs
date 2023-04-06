using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Plattform plattform;
    [SerializeField] Wall wall;
    [SerializeField] Transform left, right; 
    Vector3 spawnposition;
    System.Random n = new System.Random();
    float p;
    float y = -4.0f;
    float f;
    Vector3 newRight;
    Vector3 newLeft;

    void Awake()
    {
        Instantiate(wall, left);
        Instantiate(wall, right);
        p = n.Next(-10, 10);
        newLeft = left.position;
        newRight = right.position;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        p = n.Next(-10,10);
        y = y + 2.0f;
        spawnposition = new Vector3(p, y, 0.0f);
        Instantiate(plattform, spawnposition, Quaternion.identity);
        if(f > 1000)
        {
            newLeft = new Vector3(newLeft.x, newLeft.y + 50, newLeft.z);
            newRight = new Vector3(newRight.x, newRight.y + 50, newRight.z);
            Instantiate(wall, newLeft, Quaternion.identity);
            Instantiate(wall, newRight, Quaternion.identity);
            f = 0;
        }
        f++;  
    }
}
