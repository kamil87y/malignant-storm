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
    int sekor = 50;
    int mati;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 6f*Time.deltaTime,0);
        interval = Random.Range(1f,4);
        waktu+=Time.deltaTime;

        if(waktu >= interval)
        {
            Debug.Log(interval);
            tembakan();
            waktu=0;
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
                Instantiate(ledak,titik_s3.position,titik_s3.rotation);
                Destroy(gameObject);
               Destroy(ledak);
               
            } 
           
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
            
            Scoring.perubahan(sekor);
            
        }
    }


}



