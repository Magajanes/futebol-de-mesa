using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public float Value
    {
        get
        {
            return slider.value;
        }
        set
        {
            slider.value = value;
        }
    }

    public void Initialize(float maxValue)
    {
        slider.maxValue = maxValue;
    }
}
