using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockets : MonoBehaviour
{
    public float speed = 200f;
    int health = 8;
    public Rigidbody2D rb1;
    // Start is called before the first frame update
    void Start()
    {
        rb1.velocity = transform.right * -(speed);
       
    }

    void Update()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spaceship" || other.tag == "penghancur2"||other.tag== "force_field")
        {
            Destroy(gameObject);
        }

        if (other.tag == "laser")
        {
            health -= 1;
            //Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            } 
           
        }
    }
    
}
