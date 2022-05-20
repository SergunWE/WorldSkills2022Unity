using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;

    public void SetValue(float newValue)
    {
        value = newValue;
    }

    public void AddValue(float newValue)
    {
        value += newValue;
    }

    public float Value => value;
}
