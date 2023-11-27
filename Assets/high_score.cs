using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class high_score : MonoBehaviour
{
    public Text teks;

    int skor_lama;
    int skor_baru;
    scoring scoring;

    // Start is called before the first frame update
    void Start()
    { 
      scoring = FindObjectOfType<scoring>();
     
        skor_lama = scoring.save;

    }

    // Update is called once per frame
    void Update()
    {
        skor_baru = scoring.hitung;
        if (skor_baru > skor_lama)
        {
            
           StartCoroutine(ShowTextWithDelay());
            
            
          
        }
        else
        {

        }
    }

    IEnumerator ShowTextWithDelay()
    {

        while (true)
        {
            // Toggle the visibility of the text
            teks.enabled = !teks.enabled;

            // Wait for the specified interval before toggling again
            yield return new WaitForSeconds(4f);
        }




    }
}
