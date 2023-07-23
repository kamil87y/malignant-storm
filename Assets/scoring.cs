using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text skor;

    int jumlah;

    public void perubahan(int nilai)
    {
        jumlah+=nilai;
        tampilan();
    }
    public void tampilan()
    {
        skor.text = jumlah.ToString();

    }
   

}
