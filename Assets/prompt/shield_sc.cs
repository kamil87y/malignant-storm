using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.5f * Time.deltaTime, 0, 0,Space.World);
        transform.Rotate(0, 0, 1.1f*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D objek)
    {
        if(objek.tag== "pelindung")
        {
            Destroy(gameObject);
        }
    }
}
