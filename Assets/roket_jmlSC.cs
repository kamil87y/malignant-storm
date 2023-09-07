using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roket_jmlSC : MonoBehaviour
{
    public Text teks;
    public int jml;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jml = FindObjectOfType<gerak_sp>().jml_roket;
        tampilan();

    }
    void tampilan()
    {
        teks.text = "x "+jml.ToString();
    }
}
