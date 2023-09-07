using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject playerui;
    public GameObject gameoverscreen;

    void start(){
        gameoverscreen.SetActive(false);
    }

    public void activate()
    {
        playerui.SetActive(false);
        gameoverscreen.SetActive(true);
    }
}
