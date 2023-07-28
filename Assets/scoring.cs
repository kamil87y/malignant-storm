using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text skor;

    int jumlah;
    int hitung;
    public float waktu;

     void Start()
    {
        
    }
    public void perubahan(int nilai)
    {
        jumlah+=nilai;
        Debug.Log(jumlah);
        
    }
    public void tampilan()
    {
        
       
        while (hitung < jumlah)
        {

            pe();
           
            
           
            
            
        }
       

    }
    public void pe()
    {
        hitung++;
        skor.text = hitung.ToString();
    }

     void Update()
    {
        tampilan();
    }
}
