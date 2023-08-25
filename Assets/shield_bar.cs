using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield_bar : MonoBehaviour
{
    public Slider bar;

   public void shild(float shild_hp)
    {
        bar.value = shild_hp;
        if (shild_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
