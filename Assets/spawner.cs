using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject musuh1a, musuh1b, musuh2, musuh3a, musuh3b, musuh4, boss;
    public float waktu;
    bool kena= false;
    public float interval = 2;
    float pilih1, pilih3;
    bool locked=false;
    float timer;
    public Transform titk;
    float kemungkinan;
    
    
    // Start is called before the first frame update
    void Start()
    {
       pilih1=Random.Range(0f, 1f);
       pilih3=Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;
        
        if(waktu <= 50) // fase 1
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                if(pilih1<=0.5f){
                    summon1a();
                }
                else{
                    summon1b();
                }
            }
        }

        if (waktu >= 50 && waktu <= 100) // fase 2
        {
            if (kemungkinan <= 0.7f)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                if(pilih1<=0.5f){
                    summon1a();
                }
                else{
                    summon1b();
                }
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    if (timer >= interval)
                {
                    summon2();
                }
                }
            }
            

        }

        if (waktu >= 100 && waktu <= 150) // fase 3
        {
            if (kemungkinan <= 0.5f)
            {
                timer += Time.deltaTime;
            if (timer >= interval)
            {
                if(pilih3<=0.5f){
                    summon3a();
                }
                else{
                    summon3b();
                }
            }
            }
            else if(kemungkinan <= 0.8f)
            {
                 timer += Time.deltaTime;
            if (timer >= interval)
            {
                if(pilih1<=0.5f){
                    summon1a();
                }
                else{
                    summon1b();
                }
            }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    summon2();
                }
            }
        }
        
        if (waktu >= 150 && waktu <= 200) // fase 4
        {
            float kemungkinan = Random.Range(0f, 1f);
            if (kemungkinan <= 0.5f)
            {
                timer += Time.deltaTime;
            if (timer >= interval)
            {
                summon4();
                if (kemungkinan <=0.25f){
                    summon4();
                }
            }
            }
            else if(kemungkinan <= 0.8f)
            {
                 timer += Time.deltaTime;
            if (timer >= interval)
            {
                if(pilih3<=0.5f){
                    summon3a();
                }
                else{
                    summon3b();
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    summon2();
                }
            }
        }
        }
        
        if (waktu >= 200 && locked==false) // boss
        {
            FindObjectOfType<stage_soundtrack>().Disable();
            locked = true;
        }
    }
    

    void summon1a() {
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(musuh1a, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    void summon1b(){
        transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
        Instantiate(musuh1b, titk.position, titk.rotation);
        transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
        Instantiate(musuh1b, titk.position, titk.rotation);
        transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
        Instantiate(musuh1b, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    void summon2(){
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(musuh2, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    void summon3a(){
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(musuh3a, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    void summon3b(){
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(musuh3b, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    void summon4(){
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(musuh4, titk.position, titk.rotation);
        timer -= interval;
        kemungkinan = Random.Range(0f, 1f);
    }
    public void summonboss(){
        transform.position = new Vector2(18.67f, 0f);
        Instantiate(boss, titk.position, titk.rotation);
        timer = 0;
    }
    public void reboot(){
        waktu = 0;
        locked = false;
        pilih1=Random.Range(0f, 1f);
        pilih3=Random.Range(0f, 1f);
        if (interval > 0.25f){
            interval-=0.25f;
        }
    }
}


   

    



