using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promt_spawn : MonoBehaviour
{
    public GameObject promt;
    public GameObject darah;
    bool kena = false;
    public float interval = 2;
    float timer;
    public Transform titk;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
        Instantiate(promt, titk.position, titk.rotation);
        Instantiate(darah, titk.position, titk.rotation);
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;
        if (timer >= interval)
        {
            transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
            Instantiate(promt, titk.position, titk.rotation);
            timer -= interval;
        }




    }
}
