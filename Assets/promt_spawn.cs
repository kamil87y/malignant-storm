using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promt_spawn : MonoBehaviour
{
    public GameObject shield;
    public GameObject darah,roket;
    bool kena = false;
    float interval = 40;
    float timer;
    public Transform titk;
    float kemungkinan;


    // Start is called before the first frame update
    void Start()
    {
        kemungkinan = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;
        if (timer >= interval){
            if (kemungkinan <= 0.1f)
            {
                transform.position = new Vector2(9f, Random.Range(-4.61f, 4.61f));
                Instantiate(shield, titk.position, titk.rotation);
                timer -= interval;
                kemungkinan = Random.Range(0f, 1f);
            }
            else
            {
                transform.position = new Vector2(9f, Random.Range(-4.61f, 4.61f));
                Instantiate(roket, titk.position, titk.rotation);
                timer -= interval;
                kemungkinan = Random.Range(0f, 1f);
            }
        }




    }

    public void StageClear(){
        transform.position = new Vector2(9f, Random.Range(-4.61f, 4.61f));
        Instantiate(darah, titk.position, titk.rotation);
    }
}
