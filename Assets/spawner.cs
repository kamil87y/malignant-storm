using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objek;
    public GameObject musuh2,musuh3;
    public float waktu;
    bool kena= false;
    public float interval = 2;
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
        
        if(waktu <= 300)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(objek, titk.position, titk.rotation);
                timer -= interval;
            }



        }

        if (waktu >= 300&& waktu<=600)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh2, titk.position, titk.rotation);
                timer -= interval;
            }

        }

        if (waktu >= 600)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                Instantiate(musuh3, titk.position, titk.rotation);
                timer -= interval;
            }
        }





    }

   

    
}
