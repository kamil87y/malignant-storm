using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_background : MonoBehaviour
{
    float x = -4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x*Time.deltaTime,0,0);
        if(transform.position.x<= -22.59)
        {
            transform.position = new Vector2(22.59f, 0);
        }
    }
}
