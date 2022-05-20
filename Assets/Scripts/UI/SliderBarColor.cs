using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarColor : MonoBehaviour
{
    [SerializeField] private Color grearValue;
    [SerializeField] private Color goodValue;
    [SerializeField] private Color badValue;

    [SerializeField] private FloatVariable value;

    [SerializeField] private Image _sliderColor;

    private void Update()
    {
        if(value.Value > 60.0)
        {
            _sliderColor.color = grearValue;
            return;
        }
        if(value.Value < 30.0)
        {
            _sliderColor.color = badValue;
            return;
        }

        _sliderColor.color = goodValue;
    }
}
