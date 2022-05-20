using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rigibody.velocity;
        if(Physics.Raycast(transform.position, Vector3.down, 1f) && (velocity.x != 0 || velocity.z != 0))
        {
            audioSource.mute = false;
            return;
        }
        audioSource.mute = true;
    }
}
