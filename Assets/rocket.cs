using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
   
    public float kecepatan;
    public Rigidbody2D rb;
    public AudioSource audio;
    public GameObject roket_meledak;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "penghancur")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "dreadnought")
        {
            Instantiate(roket_meledak,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
