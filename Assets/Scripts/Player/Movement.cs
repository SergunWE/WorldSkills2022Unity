using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxSprintSpeed;

    [SerializeField] private SprintCheck sprintCheck;

    private Rigidbody _rigidbody;

    private Vector2 _inputAxis;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = _inputAxis.y * orientation.forward + _inputAxis.x * orientation.right;
        _rigidbody.AddForce(_direction * speed * speedMultiplier, ForceMode.Acceleration);
        SpeedControl();
    }

    private void SpeedControl()
    {
        if (sprintCheck == null) return;
            //текущая скорость
            Vector3 velocity = _rigidbody.velocity;
        //текущая скорость без учёта гравитации
        Vector3 speedXZ = new Vector3(velocity.x, 0, velocity.z);
        //текущая максимальная скорость
        float currentMaxSpeed = sprintCheck.SprintWork ? maxSprintSpeed : maxSpeed;
        if(speedXZ.magnitude > currentMaxSpeed)
        {
            //Debug.Log("Снижение скорости");
            velocity = speedXZ.normalized * currentMaxSpeed + Vector3.up * velocity.y;
            _rigidbody.velocity = velocity;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _inputAxis = context.ReadValue<Vector2>();
    }
}
