using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembakan : MonoBehaviour
{
    public Transform titik_tembak ;
    public Transform titk_tembak2;
    public GameObject laser_prefab;
    public AudioSource sfx_laser;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            sfx_laser.Play();
            tembak();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            sfx_laser.Play();
            tembak();
        }
    }


    void tembak()
    {
        Instantiate(laser_prefab,titik_tembak.position,titik_tembak.rotation);
        Instantiate(laser_prefab, titk_tembak2.position, titk_tembak2.rotation);
    }
}
