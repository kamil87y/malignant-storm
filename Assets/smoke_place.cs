using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_place2 : MonoBehaviour
{
    public int jml_kena;
    public GameObject ledakan,asap;
    public bool meledak = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            jml_kena++;
            FindObjectOfType<bossbehaviour>().health -= 1;
        }
        if (jml_kena >= 10&&meledak==false)
        {
            Instantiate(ledakan, gameObject.transform);
            
            meledak=true;
        }
    }
}
