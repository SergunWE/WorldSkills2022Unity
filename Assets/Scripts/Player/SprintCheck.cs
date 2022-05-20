using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprintCheck : MonoBehaviour
{
    [SerializeField] private float sprintCoef;
    [SerializeField] private FloatVariable sprintValue;

    private bool _isSpinted = false;
    private bool _sprintWork = false;

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started && sprintValue.Value > 30.0)
        {
            _isSpinted = true;
            return;
        }
        if (context.canceled)
        {
            _isSpinted = false;
            _sprintWork = false;
        }
    }

    private void Update()
    {
        if(_isSpinted)
        {
            if (sprintValue.Value > 0.0)
            {
                sprintValue.AddValue(-Time.deltaTime * sprintCoef);
                _sprintWork = true;
            }
            else
            {
                _sprintWork = false;
            }
        }
        else
        {
            if (sprintValue.Value < 100.0)
            {
                sprintValue.AddValue(Time.deltaTime * sprintCoef / 3);
            }
        }
    }

    public bool SprintWork => _sprintWork;

}
