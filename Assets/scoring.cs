using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text skor;
    public Text finalskor;
    public Text highskor;
    public GameObject highscore;
    public GameObject newhighscore;
    public int save;

    int jumlah;
    public int hitung;
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
        if (save >= jumlah){
            highskor.text = save.ToString();
        }
        else if (save < jumlah){
            highscore.SetActive(false);
            newhighscore.SetActive(true);
            PlayerPrefs.SetInt("skor", hitung);
        }
    }

     void Update()
    {
        //Debug.Log(save);
        tampilan();
    }
}
