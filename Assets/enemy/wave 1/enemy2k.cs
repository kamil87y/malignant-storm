using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2k : MonoBehaviour
{
    public GameObject proyektil;
    public GameObject ledak;
    public Transform titik_s, titik_s3;
    public AudioSource sfx;
    public int health = 100;
    float waktu = 0;
    float interval;
    scoring Scoring;
    int sekor = 120;
    int mati;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 3.5f*Time.deltaTime,0);
        interval = 2f;
        waktu+=Time.deltaTime;
         

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "penghancur2")
        {
            Destroy(gameObject);
           
        }

        if (other.tag == "laser")
        {
            health -= 1;
            FindObjectOfType<gerak_sp>().corrupthit();
            //Debug.Log(health);
            if (health <= 0)
            {
               Instantiate(ledak,titik_s3.position,titik_s3.rotation);
               Destroy(gameObject);
               FindObjectOfType<gerak_sp>().corruptkill();
            } 
           
        }

        if (other.tag == "spaceship" || other.tag == "force_field")
        {
            Instantiate(ledak,titik_s3.position,titik_s3.rotation);
            Destroy(gameObject);
            FindObjectOfType<gerak_sp>().corruptpurge();
        }

        if (other.tag == "roket")
        {
            Instantiate(ledak,titik_s3.position,titik_s3.rotation);
            Destroy(gameObject);
            FindObjectOfType<gerak_sp>().corruptkill();
        }

    }

    private void OnDestroy()
    {
        if (transform.position.x>-15)
        {
           
            FindObjectOfType<suara_Ledak>().putar();

           
            Scoring.perubahan(sekor);
            
        }
    }

}



