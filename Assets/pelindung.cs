using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelindung : MonoBehaviour
{
    public Transform titik_pel;
    public GameObject kapal;
    public GameObject shield_prefab;
    public gerak_sp gerak;
    bool x = true;
    bool y = true;

    void awake()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gerak.p == 1 && x==true)
        {
           
            Instantiate(shield_prefab, titik_pel.position, titik_pel.rotation, kapal.transform);

            x=false;
        }
        
    }

  
}
