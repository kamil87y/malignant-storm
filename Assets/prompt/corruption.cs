using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class corruption : MonoBehaviour
{
    public Slider slider;
    

    public void corruptcall(float corrupt)
    {
        slider.value = corrupt;
    }
}
