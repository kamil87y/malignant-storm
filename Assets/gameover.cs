using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject playerui;
    public GameObject gameoverscreen;
    public GameObject bosshp;

    void start(){
        gameoverscreen.SetActive(false);
        bosshp.SetActive(false);
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
}
