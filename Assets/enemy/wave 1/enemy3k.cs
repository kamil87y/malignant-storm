using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3k : MonoBehaviour
{
    public GameObject proyektil;
    public Transform titik_s, titik_s2, titik_s3;
    public AudioSource sfx;
    public int health = 100;
    float waktu = 0;
    float interval;
    scoring Scoring;
    int sekor = 50;
    int mati;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
        interval = Random.Range(2,4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 4.5f*Time.deltaTime,0);
        waktu+=Time.deltaTime;

        if(waktu >= interval)
        {
            tembakan();
            waktu=0;
            interval = Random.Range(2,4);
        }
         

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
            FindObjectOfType<gerak_sp>().Corruption();
            //Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
               
               
            } 
           
        }
    }

    


    void tembakan()
    {
        Instantiate(proyektil,titik_s.position,titik_s.rotation);
        Instantiate(proyektil,titik_s2.position,titik_s2.rotation);
        Instantiate(proyektil,titik_s3.position,titik_s3.rotation);
        sfx.Play();

    }

    private void OnDestroy()
    {
        if (transform.position.x>-11)
        {

            Scoring.perubahan(sekor);
            
        }
    }


}



