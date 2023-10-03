using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbehaviour : MonoBehaviour
{
    public GameObject proyektil, proyektil2, ledak;
    public Transform titik_s, titik_s2, titik_s3, titik_s4, titik_s5, titik_s6;
    public Transform titik_d, titik_d2, titik_d3, titik_d4, titik_d5, titik_d6;
    public Transform titik_r;
    public AudioSource sfx;
    darah_boss darah_boss;
    public int health=100;
    [Header("efek damage")]
    public GameObject smoke;
    public Transform smoke_place1,smoke_place2;
    int maxhp;
    float waktu1 = 0, waktu2 = 0;
    float intervalgun = 1.25f;
    float intervalrocket = 0.25f;
    scoring Scoring;
    int sekor = 2000;
    int mati;
    int firemode=1;
    [Header("roket")]
    public bool rocketmode=false;
    public int rocketcount, rocketcountlimit=8;
    public float rockettime;
    bool rocketlock = true;
    bool Buff1=false, Buff2=false, Buff3=false;
    [Header("indikator meledak")]
    bool meledakIND1 = false;
    bool meledakIND2 = false;

    float movespeed = 3f;
    float sidespeed = 0;
    float multiplier = 1f;
   
  
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<gameover>().enable();
        darah_boss=FindObjectOfType<darah_boss>();
        Scoring = FindObjectOfType<scoring>();
        maxhp = health; 
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sidespeed*Time.deltaTime, movespeed*Time.deltaTime,0);
       
    
        if (!rocketlock){
            rockettime+=Time.deltaTime;
            if (rocketmode){
                waktu2+=Time.deltaTime;
            }
        }

        if(!rocketmode){
            waktu1+=Time.deltaTime;
            if(waktu1 >= intervalgun && firemode==1 )
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
        }

        if(rockettime >= 10){
            if (rocketmode == false){
                rocketmode = true;
            }
            if(waktu2 >= intervalrocket){
                tembakan_r();
                waktu2=0;
                rocketcount++;
            }
            if(rocketcount==rocketcountlimit){
                rocketmode = false;
                rocketcount = 0;
                rockettime = 0;
            }
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
            rocketcountlimit = 12;
            waktu1=0;
            Buff2=true;
        }

         if(health<maxhp*0.25 && Buff3 == false)
         {
            intervalgun = 0.75f;
            multiplier = 2.5f;
            rocketcountlimit = 16;
            intervalrocket = 0.2f;
            waktu1=0;
            waktu2=0;
            Buff3=true;
         }
        ledakan_asap();

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
            darah_boss.Health(health);
            //Debug.Log(health);
            if (health <= 0)
            {
                FindObjectOfType<boss_soundtrack>().Disable();
                Destroy(gameObject);
                Instantiate(ledak,titik_r.position,titik_r.rotation);
                FindObjectOfType<gerak_sp>().corruptkill();
            } 
           
        }

        if (other.tag == "roket")
        {
            health -= 5;
            FindObjectOfType<gerak_sp>().corrupthit();
            darah_boss.Health(health);
            //Debug.Log(health);
            if (health <= 0)
            {
                FindObjectOfType<boss_soundtrack>().Disable();
                Destroy(gameObject);
                Instantiate(ledak,titik_r.position,titik_r.rotation);
                FindObjectOfType<gerak_sp>().corruptkill();
            } 
        }

        if (other.tag == "spaceship"){
            FindObjectOfType<gerak_sp>().killingblow();
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

        Instantiate(proyektil2,titik_r.position,titik_r.rotation);

    }


    private void OnDestroy()
    {
        if (transform.position.x>-15)
        {
            FindObjectOfType<suara_Ledak>().putar();
            Scoring.perubahan(sekor);
            FindObjectOfType<gameover>().disable();
            FindObjectOfType<promt_spawn>().StageClear();
            
        }
    }

    void ledakan_asap()
    {
        if (FindObjectOfType<smoke_place>().meledak == true&& meledakIND1==false)
        {
            Instantiate(smoke, smoke_place1.position, smoke_place1.rotation, smoke_place1.transform);
            meledakIND1 = true;
            
        }
        if(FindObjectOfType<smoke_place2>().meledak == true &&meledakIND2==false)
        {
            Instantiate(smoke, smoke_place2.position, smoke_place2.rotation, smoke_place2.transform);
            meledakIND2 = true;
        }
    }

}



