using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_enemy : MonoBehaviour
{
   
    public float kecepatan;
    public Rigidbody2D rb;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * kecepatan;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spaceship" || other.tag == "penghancur2"||other.tag== "force_field")
        {
            Destroy(gameObject);
        }
    }
}
