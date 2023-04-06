using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField]Transform startposition;
    Vector2 left = new Vector2(-4.0f, 0.0f);
    Vector2 right = new Vector2(4.0f, 0.0f);
    float vx;
    float vy;
    Vector2 up;
    public int jumps;
    float fall = 5.0f;
    CameraController camera;

    void Awacke()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startposition = startposition;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody.position  = this.startposition.position;
        jumps = 0;
        this.camera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        vx = this.rigidbody.velocity.x;
        up = new Vector2(0.0f, jump(vx));
        if(this.camera.transform.position.y-fall > this.rigidbody.position.y)
        {
           SceneManager.LoadScene("LoseScreen");
        }

        if(Input.GetKey(KeyCode.A))
        {
            //hier wird speed in eine richtung geändert
            this.rigidbody.AddForce(left);
        }
        if(Input.GetKey(KeyCode.D))
        { 
            this.rigidbody.AddForce(right);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Vector2 test = new Vector2(0.0f, 1000f);
            //this.rigidbody.AddForce(test);
            if(jumps < 1)
            {
                this.rigidbody.AddForce(up);
                jumps++;
            }
        }
        

        
    }
    void FixedUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Plattform")
        {
            jumps = 0;
        }
        if(other.gameObject.tag == "Wall")
        {
            this.rigidbody.AddForce(new Vector2(-20 * vx, 0.0f));
        }
    }

    float jump(float vx) 
    {
        float j = 200.0f;//standard jump height
        if(vx > 0.0f)
        {
            j = vx * 50.0f +j;//velocity in direction * 50 + standard jump height
            return j;
        }
        else if(vx < 0.0f)
        {
            j = vx * -50.0f + j;
            return j;
        }
        return j;
        
        
    }
}
