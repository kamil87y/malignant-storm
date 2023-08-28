using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2behaviour : MonoBehaviour
{
    public GameObject proyektil;
    public Transform titik_f;
    public Transform titik_l;
    public Transform titik_r;
    public AudioSource sfx;
    public int health=100;
    int maxhp;
    float waktu = 0;
    float intervalgun = 1.25f;
    scoring Scoring;
    int sekor = 500;
    int mati;
    int firemode=1;
    bool Buff1=false, Buff2=false;
    bool charge = false;
    float movespeed = 3f;
    float sidespeed = 0;
    float multiplier = 1f;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Scoring = FindObjectOfType<scoring>();
        maxhp = health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sidespeed*Time.deltaTime, movespeed*Time.deltaTime,0);
        waktu+=Time.deltaTime;

        if(waktu >= intervalgun && firemode==1)
        {
            tembakan_s();
            waktu=0;
            firemode = 2;
        }
        if(waktu >= intervalgun && firemode==2)
        {
            tembakan_d();
            waktu=0;
            firemode = 1;
        }

        if(health<maxhp*0.67 && Buff1 == false)
        {
            multiplier = 1.25f;
            waktu=0;
            Buff1=true;
        }

        if(health<maxhp*0.33 && Buff2 == false)
        {
            intervalgun = 1f;
            multiplier = 1.75f;
            waktu=0;
            Buff2=true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "penghancur2")
        {
            Destroy(gameObject);
           
        }

        if (other.tag == "laser" && !charge)
        {
            health -= 1;
            FindObjectOfType<gerak_sp>().corrupthit();
            //Debug.Log(health);
            if (health <= 0)
            {
                FindObjectOfType<boss_soundtrack>().Disable();
                FindObjectOfType<spawnertest>().reboot();
                Destroy(gameObject);
            } 
           
        }

        if (other.tag == "bosslimit1"){
            movespeed=0f;
            sidespeed=2f*multiplier;
        }
        if (other.tag == "bosslimit2"){
            sidespeed=-2f*multiplier;
        }
    }

    


    void tembakan_s()
    {

    }

    void tembakan_d()
    {
        Instantiate(proyektil,titik_l.position,titik_l.rotation);
        Instantiate(proyektil, titik_f.position, titik_f.rotation);

            
        sfx.Play();

    }

    void tembakan_r()
    {

            
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



