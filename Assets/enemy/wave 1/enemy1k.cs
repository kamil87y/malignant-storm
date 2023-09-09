using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1k : MonoBehaviour
{
    public GameObject proyektil;
    public GameObject ledak;
    public Transform titik_s, titik_s3;
    public AudioSource sfx;
    public int health = 100;
    float waktu = 0;
    float interval;
    scoring Scoring;
    int sekor = 5;
    int mati;
    int fire=1;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
        interval = Random.Range(2f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 7f*Time.deltaTime,0);
        waktu+=Time.deltaTime;

        if(waktu >= interval && fire==1)
        {
            tembakan();
            waktu=0;
            fire=2;
        }

        if(waktu >= 0.3f && fire==2)
        {
            tembakan();
            waktu=0;
            fire=1;
            interval = Random.Range(2f,5f);
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
            FindObjectOfType<gerak_sp>().corrupthit();
            //Debug.Log(health);
            if (health <= 0)
            {
                Instantiate(ledak,titik_s3.position,titik_s3.rotation);
                Destroy(gameObject);
            } 
           
        }

        if (other.tag == "spaceship" || other.tag == "force_field" || other.tag == "roket")
        {
            Instantiate(ledak,titik_s3.position,titik_s3.rotation);
            Destroy(gameObject);
        }
    }

    void tembakan()
    {
        Instantiate(proyektil,titik_s.position,titik_s.rotation);
        sfx.Play();
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



