using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask attackingLayer;
    [SerializeField] private FloatVariable playerHP;

    [SerializeField] private AudioSource attackAudioSource;
       

    private Collider[] objects;
    private bool _canAttack = true;

    private void FixedUpdate()
    {
        objects = Physics.OverlapSphere(transform.position, 5f, attackingLayer);
        if(objects.Length > 0 && _canAttack)
        {
            StartCoroutine(AttackDelay());
            playerHP.AddValue(-damage);
            attackAudioSource.Play();
        }
    }

    private IEnumerator AttackDelay()
    {
        _canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        _canAttack = true;
    }
}
