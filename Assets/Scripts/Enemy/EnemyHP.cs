using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float hp;

    [SerializeField] private AudioSource deadSource;

    public void TakeDamage(float damage)
    {
        hp-=damage;
        if(hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
