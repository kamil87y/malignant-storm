using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject musuh1, musuh2, musuh3, musuh4, boss;
    public float waktu;
    bool kena= false;
    public float interval = 2;
    bool locked=false;
    float timer;
    public Transform titk;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;
        
        if(waktu <= 300) // fase 1
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh1, titk.position, titk.rotation);
                timer -= interval;
            }



        }

        if (waktu >= 300&& waktu<=600) // fase 2
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh2, titk.position, titk.rotation);
                timer -= interval;
            }

        }

        if (waktu >= 00) // fase 3
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh3, titk.position, titk.rotation);
                timer -= interval;
            }
        }
        
        if (waktu >= 600&& waktu<=300) // fase 4
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh2, titk.position, titk.rotation);
                timer -= interval;
            }

        }
        
        if (waktu >= 600 && locked==false) // boss
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                FindObjectOfType<stage_soundtrack>().Disable();
                Instantiate(musuh2, titk.position, titk.rotation);
                timer -= interval;
                locked = true;
            }

        }

        




    }
    public void reboot()
    {
        waktu = 0;
           locked = false;
    }

   

    
}


