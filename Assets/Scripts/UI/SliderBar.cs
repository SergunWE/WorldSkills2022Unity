using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private FloatVariable value;

    private Slider _slider;

    private void Awake()
    {
        value.SetValue(100);
        _slider = GetComponent<Slider>();
        _slider.value = 100;
    }

    private void Update()
    {
        _slider.value = value.Value;
    }
}
