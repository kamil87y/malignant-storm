using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_musuh : MonoBehaviour
{
    public GameObject proyektil;
    public Transform titik_s;
    public Transform titik_s2;
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
        interval = Random.Range(1,4);
        waktu+=Time.deltaTime;

        if(waktu >= interval)
        {
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



