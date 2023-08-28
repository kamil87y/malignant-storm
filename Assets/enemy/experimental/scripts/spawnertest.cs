using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnertest : MonoBehaviour
{
    public GameObject musuh1, musuh2, musuh3, musuh4, boss;
    public GameObject boss1limit;
    public Text phasestatus;
    public float waktu, interval;
    float timer;
    public Transform titk, limit;
    public int phase=1;
    public int choice;
    bool locked=false;
    
    
    // Start is called before the first frame update
    void Start()
    {
       choice=Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase<5){
            waktu += Time.deltaTime;
        }
        
        if(waktu <= 20)
        {
            if(waktu>=3 && locked && phase==1){
                locked = false;
                waktu = 0;
            }
            if(!locked){
                timer += Time.deltaTime;
            }
            
                switch(phase) 
            {
                    case 1:
                        if (timer >= interval)
                        {
                            transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                            Instantiate(musuh1, titk.position, titk.rotation);
                            transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                            Instantiate(musuh1, titk.position, titk.rotation);
                            transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                            Instantiate(musuh1, titk.position, titk.rotation);
                            timer -= interval;
                        }
                    break;

                    case 2:
                    if (timer >= interval){
                            if (choice<=7){
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                            else{
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh2, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                        }
                    break;

                    case 3:
                    if (timer >= interval){
                            if (choice<=5){
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh3, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                            else if (choice<=8){
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                transform.position = new Vector2(Random.Range(16.67f, 20.67f), Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh1, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                            else{
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh3, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                        }
                    break;

                    case 4:
                    if (timer >= interval){
                            if (choice<=5){
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh4, titk.position, titk.rotation);
                                if (choice>3){
                                    transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                    Instantiate(musuh4, titk.position, titk.rotation);
                                }
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                            else if (choice<=8){
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh3, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                            else{
                                transform.position = new Vector2(18.67f, Random.Range(-4.61f, 4.61f));
                                Instantiate(musuh2, titk.position, titk.rotation);
                                timer -= interval;
                                choice=Random.Range(1,11);
                            }
                        }
                    break;

                    case 5:
                        switch(choice)
                        {
                            case 1:
                                if (timer >= 7 && !locked){
                                    transform.position = new Vector2(18.67f, 0f);
                                    Instantiate(boss, titk.position, titk.rotation);
                                    locked = true;
                                    timer = 0;
                                }
                            break;
                        }
                    break;
            }
        }   

        if (waktu >= 20)
        {
            waktu = 0;
            if(phase<5){
                phase++;
            }
            if(phase==5){
                choice=1;
                FindObjectOfType<stage_soundtrack>().Disable();
                Instantiate(boss1limit,limit.position, limit.rotation);
            }
        }
        phasestatus.text=phase.ToString();
    }

    public void reboot(){
        phase=1;
    }
}