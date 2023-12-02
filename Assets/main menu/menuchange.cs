using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuchange : MonoBehaviour
{
    SpriteRenderer spriterenderer;
    public Sprite main, credits;
    public GameObject mainobject, creditobject;
    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tomain(){
        spriterenderer.sprite = main;
        mainobject.SetActive(true);
        creditobject.SetActive(false);
    }
    
    public void tocredits(){
        spriterenderer.sprite = credits;
        mainobject.SetActive(false);
        creditobject.SetActive(true);
    }
}
