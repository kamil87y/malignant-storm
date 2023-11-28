using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelindung : MonoBehaviour
{
    public Transform titik_pel;
    public GameObject kapal;
    public GameObject shield_prefab;
    public gerak_sp gerak;
    public GameObject teks_shieldbar;
    shield_mechanic shield_Mechanic;
    
   bool kena = false;
    public bool shiedl_active=false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        shield_Mechanic=FindObjectOfType<shield_mechanic>();
        if (kena == false)
        {
            teks_shieldbar.SetActive(false);


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void aktifshield()
    {
       
        if (kena == true)
        {
            teks_shieldbar.SetActive(true);//shield bar
            Debug.Log("k");
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shield" && shiedl_active==false)
        {
           
            Instantiate(shield_prefab, titik_pel.position, titik_pel.rotation, kapal.transform);
            Debug.Log("p");
            kena = true;
            shiedl_active = true;
            
        }
        aktifshield();

         
      
    }

}
