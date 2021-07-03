using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 10.0f;
    public float boundY = 4.0f;
    public GameObject Ball;
    private Rigidbody2D rb2d;
    private Rigidbody2D ballrb2d;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        Ball = GameObject.Find("Ball");
        ballrb2d = Ball.GetComponent<Rigidbody2D>();

        var pos = transform.position;
        var vel = rb2d.velocity;

        if (ballrb2d.velocity.y > 0.0 && ballrb2d.position.y > (rb2d.position.y) )
        {
            vel.y = speed;
        }
        else if (ballrb2d.velocity.y < 0.0 && ballrb2d.position.y < (rb2d.position.y)  )
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;

        Debug.Log("Y Position of Ball : " + ballrb2d.position.y);
        Debug.Log("Y Position of Enemy : " + rb2d.position.y);

    }
}
