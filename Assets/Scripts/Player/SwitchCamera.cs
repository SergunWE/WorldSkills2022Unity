using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private GameObject tpsCamera;

    private bool _isFps = true;

    private void Awake()
    {
        SetCamera();
    }

    private void SetCamera()
    {
        //включаем нужную камеру
        if(_isFps)
        {
            fpsCamera.SetActive(true);
            tpsCamera.SetActive(false);
            return;
        }
        fpsCamera.SetActive(false);
        tpsCamera.SetActive(true);
    }

    private void Switch()
    {
        _isFps = !_isFps;
        SetCamera();
    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Switch();
        }
    }
    /// <summary>
    /// Получить объект вблизи игрока, на который он навёлся прицелом
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectInCenterCamera(float distanse)
    {
        RaycastHit hit;
        Transform currentCamera = _isFps ? fpsCamera.transform : tpsCamera.transform;
        if(Physics.Raycast(currentCamera.position, currentCamera.forward, out hit, _isFps ? distanse : distanse + 5))
        {
            Debug.Log(hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        return null;
    }

    public Camera GetCurrentCamera()
    {
        return _isFps ? fpsCamera.GetComponent<Camera>() : tpsCamera.GetComponent<Camera>();
    }

    public bool IsFps => _isFps;

}
