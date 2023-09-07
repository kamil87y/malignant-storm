using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text skor;
    public Text finalskor;

    int jumlah;
    int hitung;
    public float waktu;

     void Start()
    {
        
    }
    public void perubahan(int nilai)
    {
        jumlah+=nilai;
        
        
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
    
    public void gameover(){
        finalskor.text = hitung.ToString();
    }

     void Update()
    {
        tampilan();
    }
}
