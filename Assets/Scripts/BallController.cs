using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 prevVector; 
    public float speed = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
        prevVector = rb2d.velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Vertical Velocity of Ball : " + rb2d.velocity.y);
      //  Debug.Log("Horizontal Velocity of Ball : " + rb2d.velocity.x);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        Vector2 vel;
       

        if (coll.collider.CompareTag("Player") || coll.collider.CompareTag("Enemy") )
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel * speed;

            Debug.Log("Hit a player. ");



        }
        else if (coll.collider.CompareTag("Border"))
        {
            Debug.Log("Hit a wall. ");

           //Don't think this is correct, maybe use position of x instead of vector
           if(rb2d.velocity.x == prevVector.x)
           {
                    Debug.Log("Stuck going up and down.");
                   
           }
            
            else
            {
                prevVector = rb2d.velocity;
            }

          
        }

        
    }
}
