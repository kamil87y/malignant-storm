using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_corruption : MonoBehaviour
{
    public GameObject missile;
    float waktu, timer;
    float interval = 0.2f;
    bool corrupt=false;
    public Transform titk;
    

    // Update is called once per frame
    void Update()
    {
        if (corrupt==true)
        {
            waktu += Time.deltaTime;
            timer += Time.deltaTime;
        }

        if (timer >= interval)
        {
            transform.position = new Vector2(-18.67f, Random.Range(-4.61f, 4.61f));
            Instantiate(missile, titk.position, titk.rotation);
            timer -= interval;
        }

        if (waktu >= 10f)
        {
            corrupt = false;
            waktu = 0;
            timer = 0;
            FindObjectOfType<gameover>().specialunleashed();
        }
    }

    public void corruptunleash(){
        corrupt = true;
    }
}


   

    



