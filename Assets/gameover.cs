using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject playerui;
    public GameObject gameoverscreen;
    public GameObject bosshp;
    public GameObject specialattack;
    float waktu;
    bool ready=false;
    bool locked=false;

    void start(){
        gameoverscreen.SetActive(false);
        bosshp.SetActive(false);
        specialattack.SetActive(false);
    }

    void Update(){
        if (ready && !locked){
            waktu+=Time.deltaTime;
            if (waktu >= 5){
                specialattack.SetActive(false);
                locked = true;
                waktu = 0;
            }
        }
    }

    public void activate()
    {
        playerui.SetActive(false);
        gameoverscreen.SetActive(true);
    }
    public void enable(){
        bosshp.SetActive(true);
    }
    public void disable(){
        bosshp.SetActive(false);
    }
    public void specialready(){
        if (!ready){
            specialattack.SetActive(true);
        }
        ready = true;
    }
    public void specialunleashed(){
        ready = false;
        locked = false;
    }
}
