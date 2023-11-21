using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text skor;
    public Text finalskor;
    int save;

    int jumlah;
    int hitung;
    public float waktu;

     void Start()
    {
        save = PlayerPrefs.GetInt("skor");
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
        PlayerPrefs.SetInt("skor", hitung);
        
    }

     void Update()
    {
        Debug.Log(save);
        tampilan();
    }
}
