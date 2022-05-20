using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform orientation;

    [SerializeField] private Transform playerRig;

    [SerializeField] private float sens;

    private Vector2 _inputAxis;

    private float _xRotation;
    private float _yRotation;

    private void Update()
    {
        if(_inputAxis != Vector2.zero)
        {
            _xRotation -= _inputAxis.y * sens;
            _yRotation += _inputAxis.x * sens;
            //ограничиваем угол поворота по оси х
            _xRotation = Mathf.Clamp(_xRotation, -70, 70);
            cameraHolder.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
            Vector3 rigRotate = playerRig.rotation.eulerAngles;
            playerRig.rotation = Quaternion.Euler(rigRotate.x, rigRotate.y, _xRotation);
            _inputAxis = Vector2.zero;
        }
        
    }

    public void OnView(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _inputAxis = context.ReadValue<Vector2>();
        }
    }
}
