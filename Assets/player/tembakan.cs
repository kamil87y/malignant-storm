using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembakan : MonoBehaviour
{
    public Transform titik_tembak ;
    public Transform titk_tembak2;
    public GameObject laser_prefab;
    public AudioSource sfx_laser;
    public float timer;
    bool shoot = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.25f && shoot)
        {
            sfx_laser.Play();
            tembak();
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("pressed");
            shoot = true;
            sfx_laser.Play();
            tembak();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            shoot = true;
            sfx_laser.Play();
            tembak();
            timer = 0;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("released");
            shoot = false;
        }

        
        if (Input.GetKeyUp(KeyCode.JoystickButton2)){
            shoot = false;
        }
    }


    void tembak()
    {
        Instantiate(laser_prefab,titik_tembak.position,titik_tembak.rotation);
        Instantiate(laser_prefab, titk_tembak2.position, titk_tembak2.rotation);
    }
}