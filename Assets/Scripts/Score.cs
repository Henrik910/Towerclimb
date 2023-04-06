using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static float score;
    CameraController c;
    private void Awacke()
    {
        
    }

    private void Start()
    {
        score = 0f;
        this.c = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        score =  this.c.transform.position.y * 10f;
    }
    
    public static float GetScore()
    {
        return score;
    }
}
