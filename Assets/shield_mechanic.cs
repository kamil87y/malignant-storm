using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_mechanic : MonoBehaviour
{
    public int shield_value = 100;
    shield_bar shield_Bar;
    pelindung pelindung;
    
    // Start is called before the first frame update
    void Start()
    {
        
        shield_Bar=FindObjectOfType<shield_bar>();
        pelindung = FindObjectOfType<pelindung>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shield_value<=0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "laser_musuh" || collision.tag== "enemy" || collision.tag == "roket_musuh")
        {
           
            shield_value -= 10;
            shield_Bar.shild(shield_value);

            
        }
        else if(collision.tag== "shield")
        {
            shield_value = 100;
        }
    }

    private void OnDestroy()
    {
        pelindung.shiedl_active = false;
    }
}
