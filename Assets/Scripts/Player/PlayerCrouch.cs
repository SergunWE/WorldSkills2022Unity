using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] private Vector3 crouchScale = new Vector3(1f, 0.5f, 1f);

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            transform.localScale = crouchScale;
            return;
        }
        if(context.canceled)
        {
            transform.localScale = Vector3.one;
        }
    }
}
