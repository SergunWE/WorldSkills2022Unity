using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask attackingLayer;

    [SerializeField] private AudioSource idleSource;
    [SerializeField] private AudioSource detectedAudioSource;

    private Rigidbody _rigidbody;

    private bool _isMove = false;

    private Collider[] objects;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    private IEnumerator Move()
    {
        _isMove = true;
        yield return new WaitForSeconds(Random.RandomRange(2f, 15f));
        _isMove=false;
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * speed + Vector3.down * 4;
        objects = Physics.OverlapSphere(transform.position, 20f, attackingLayer);

        if (objects.Length > 0)
        {
            transform.LookAt(objects[0].transform);
            if(idleSource.mute == false)
            {
                detectedAudioSource.Play();
                idleSource.mute = true;
            }
            
        }
        else
        {
            idleSource.mute = false;
            if (!_isMove)
            {
                transform.rotation = Quaternion.Euler(0, Random.RandomRange(0f, 360f), 0);
                StartCoroutine(Move());
            }
        }

    
    }
}
