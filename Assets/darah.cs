using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class darah : MonoBehaviour
{
    public Slider slider;
    

    public void Health(float HP)
    {
        slider.value = HP;
    }
}
