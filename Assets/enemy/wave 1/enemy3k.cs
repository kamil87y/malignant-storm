using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3k : MonoBehaviour
{
    public GameObject proyektil;
    public GameObject ledak;
    public Transform titik_s, titik_s2, titik_s3, titik_s4;
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
            FindObjectOfType<gerak_sp>().corrupthit();
            //Debug.Log(health);
            if (health <= 0)
            {
               Instantiate(ledak,titik_s4.position,titik_s4.rotation);
               Destroy(gameObject);
               FindObjectOfType<gerak_sp>().corruptkill();
            }
        }
        if (other.tag == "spaceship" || other.tag == "force_field" || other.tag == "roket")
        {
            Instantiate(ledak,titik_s4.position,titik_s4.rotation);
            Destroy(gameObject);
            FindObjectOfType<gerak_sp>().corruptkill();
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
        if (transform.position.x>-15)
        {
           
            FindObjectOfType<suara_Ledak>().putar();

           
            Scoring.perubahan(sekor);
            
        }
    }


}



