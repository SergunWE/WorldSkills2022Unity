using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            _rigibody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
