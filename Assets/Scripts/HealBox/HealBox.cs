using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour, IHealble
{
    [SerializeField] private float healValue;

    public float Heal()
    {
        return healValue;
    }
}
