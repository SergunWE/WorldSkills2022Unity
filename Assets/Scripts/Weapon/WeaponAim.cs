using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private SwitchCamera switchCamera;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private GameObject aimSprite;
    [SerializeField] private GameObject fpsWeapon;
    [SerializeField] private Vector3 mushkaPosition;

    private Camera _camera;
    private float fovChangeValue;

    public void OnAim(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _camera = switchCamera.GetCurrentCamera();
            WeaponData weaponData = weaponManager.WeaponData;
            fovChangeValue = weaponData == null ? 0 : weaponData.zoom;
            
            if(switchCamera.IsFps)
            {
                aimSprite.SetActive(false);
                StopAllCoroutines();
                StartCoroutine(Lerp(fpsWeapon.transform.localPosition, mushkaPosition));
                StartCoroutine(Lerp(_camera.fieldOfView, _camera.fieldOfView - fovChangeValue));
                }
        }
        if(context.canceled)
        {
            
            aimSprite.SetActive(true);
            
            StopAllCoroutines();
            StartCoroutine(Lerp(fpsWeapon.transform.localPosition, Vector3.zero));
            StartCoroutine(Lerp(_camera.fieldOfView, 90));
        }
    }

    private IEnumerator Lerp(Vector3 startPos, Vector3 finishPos)
    {
        float time = 0.0f;
        float duration = 0.1f;
        while(time < duration)
        {
            fpsWeapon.transform.localPosition = Vector3.Lerp(startPos, finishPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        fpsWeapon.transform.localPosition = finishPos;
    }

    private IEnumerator Lerp(float startPos, float finishPos)
    {
        float time = 0.0f;
        float duration = 0.1f;
        while (time < duration)
        {
            _camera.fieldOfView = Mathf.Lerp(startPos, finishPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _camera.fieldOfView = finishPos;
    }
}
