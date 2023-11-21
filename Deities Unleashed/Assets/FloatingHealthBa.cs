using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBa : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float currentval, float maxvalue)
    {
        slider.value = currentval / maxvalue;
    }

}
