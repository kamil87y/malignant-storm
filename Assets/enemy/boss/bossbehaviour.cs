using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbehaviour : MonoBehaviour
{
    public GameObject proyektil, proyektil2;
    public Transform titik_s, titik_s2, titik_s3, titik_s4, titik_s5, titik_s6;
    public Transform titik_d, titik_d2, titik_d3, titik_d4, titik_d5, titik_d6;
    public Transform titik_r, titik_r2, titik_r3, titik_r4, titik_r5, titik_r6, titik_r7;
    public AudioSource sfx;
    public int health=100;
    int maxhp;
    float waktu1 = 0, waktu2 = 0;
    float intervalgun = 1.25f;
    float intervalrocket = 5f;
    scoring Scoring;
    int sekor = 500;
    int mati;
    int firemode=1;
    int rocketspread=1;
    bool rocketlock = true;
    bool Buff1=false, Buff2=false, Buff3=false;
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
        waktu1+=Time.deltaTime;
        if (!rocketlock){
            waktu2+=Time.deltaTime;
        }

        if(waktu1 >= intervalgun && firemode==1)
        {
            tembakan_s();
            waktu1=0;
            firemode = 2;
        }
        if(waktu1 >= intervalgun && firemode==2)
        {
            tembakan_d();
            waktu1=0;
            firemode = 1;
        }

        if(waktu2 >= intervalrocket){
            tembakan_r();
            waktu2=0;
        }

        if(health<maxhp*0.75 && Buff1 == false)
        {
            rocketlock = false;
            multiplier = 1.25f;
            waktu1=0;
            Buff1=true;
        }

        if(health<maxhp*0.5 && Buff2 == false)
        {
            intervalgun = 1f;
            multiplier = 1.75f;
            waktu1=0;
            Buff2=true;
        }

         if(health<maxhp*0.25 && Buff3 == false)
         {
            intervalgun = 0.75f;
            multiplier = 2.5f;
            waktu1=0;
            waktu2=0;
            Buff3=true;
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
                FindObjectOfType<boss_soundtrack>().Disable();
                FindObjectOfType<spawner>().reboot();
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
        Instantiate(proyektil,titik_s.position,titik_s.rotation);
        Instantiate(proyektil, titik_s.position,titik_s2.rotation);
        Instantiate(proyektil, titik_s.position,titik_s3.rotation);
        Instantiate(proyektil,titik_s4.position,titik_s4.rotation);
        Instantiate(proyektil, titik_s4.position,titik_s5.rotation);
        Instantiate(proyektil, titik_s4.position,titik_s6.rotation);
            
        sfx.Play();

    }

    void tembakan_d()
    {
        Instantiate(proyektil,titik_d.position,titik_d2.rotation);
        Instantiate(proyektil, titik_d.position, titik_d3.rotation);
        Instantiate(proyektil, titik_d4.position, titik_d5.rotation);
        Instantiate(proyektil,titik_d4.position,titik_d6.rotation);
            
        sfx.Play();

    }

    void tembakan_r()
    {
        if (rocketspread==1){
            Instantiate(proyektil2,titik_r.position,titik_r.rotation);
            Instantiate(proyektil2, titik_r.position, titik_r2.rotation);
            Instantiate(proyektil2, titik_r.position, titik_r3.rotation); 
            if (Buff2==true){
                Instantiate(proyektil2, titik_r.position, titik_r4.rotation);
                Instantiate(proyektil2, titik_r.position, titik_r5.rotation);
            }
            rocketspread=2;
        }
        else if (rocketspread==2){
            Instantiate(proyektil2,titik_r.position,titik_r.rotation);
            Instantiate(proyektil2, titik_r.position, titik_r4.rotation);
            Instantiate(proyektil2, titik_r.position, titik_r5.rotation); 
            if (Buff2==true){
                Instantiate(proyektil2, titik_r.position, titik_r6.rotation);
                Instantiate(proyektil2, titik_r.position, titik_r7.rotation);
            }
            rocketspread=1;
        }
            
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



