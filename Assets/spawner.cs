using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objek;
    bool kena= false;
    public float interval = 3;
    float timer;
    public Transform titk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>= 4.61)
        {
            kena=true;
        }

        if (transform.position.y <= -4.61)
        {
            kena = false;
        }

        if (kena == true)
        {
            transform.Translate(-0.001f, 0, 0);
        }

        if (kena == false)
        {
            transform.Translate(0.001f, 0,0);
        }

        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Instantiate(objek,titk.position,titk.rotation);
            timer-=interval;
        }




    }
}
