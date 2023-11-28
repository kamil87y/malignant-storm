using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class darah_boss : MonoBehaviour
{
    public Slider slider;
    

    public void Health(float HP)
    {
        slider.value = HP;
    }
    public void enable(){
        gameObject.SetActive(true);
    }
    public void disable(){
        gameObject.SetActive(false);
    }
}
