using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_musuh : MonoBehaviour
{
    public GameObject proyektil;
    public GameObject ledak;
    public Transform titik_s;
    public Transform titik_s2;
    public Transform titik_s3;
    public AudioSource sfx;
    public int health = 100;
    float waktu = 0;
    float interval;
    scoring Scoring;
    int sekor = 25;
    int mati;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
        interval = Random.Range(2f,4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 6f*Time.deltaTime,0);
        
        waktu+=Time.deltaTime;

        if(waktu >= interval)
        {
            Debug.Log(interval);
            tembakan();
            waktu=0;
            interval = Random.Range(1f,4f);
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
        Instantiate(proyektil, titik_s2.position, titik_s2.rotation);
            
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



