using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2k : MonoBehaviour
{
    public GameObject proyektil;
    public Transform titik_s;
    public AudioSource sfx;
    public int health = 100;
    float waktu = 0;
    float interval;
    scoring Scoring;
    int sekor = 100;
    int mati;
    int fire=1;
   
  
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

        if(waktu >= interval && fire==1)
        {
            tembakan();
            waktu=0;
            fire=2;
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



