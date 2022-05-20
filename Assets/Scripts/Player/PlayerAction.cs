using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private SwitchCamera switchCamera;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private BulletManager bulletManager;

    [SerializeField] private GameObject dropWeaponPrefab;
    [SerializeField] private Transform orientation;

    [SerializeField] private GameObject[] playerObjects;

    public void OnAction(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Action(switchCamera.GetObjectInCenterCamera(5));
        }    
    }

    public void OnDropWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("Drop");
        if (context.performed)
        {
            WeaponData weaponData = weaponManager.WeaponData;
            if (weaponData == null) return;
            GameObject drop = Instantiate(dropWeaponPrefab, 1.4f * orientation.forward + transform.position, new Quaternion());
            DropWeapon dropComponent = drop.GetComponent<DropWeapon>();
            dropComponent.SetWeaponData(weaponData, bulletManager.ClipBullet, bulletManager.MaxBullet);
            weaponManager.UpdateWeaponView(null);
        }
    }

    private void Action(GameObject gameObject)
    {
        if(gameObject == null)
        {
            return;
        }
        if(gameObject.TryGetComponent(out IDropableWeapon component))
        {
            WeaponData dropWeaponData = component.WeaponData();
            int newClipBullet = component.GetClipBullet();
            int newMaxBullet  = component.GetMaxBullet();
            component.SetWeaponData(weaponManager.WeaponData, bulletManager.ClipBullet, bulletManager.MaxBullet);
            weaponManager.UpdateWeaponView(dropWeaponData);
            bulletManager.SetBullets(newClipBullet, newMaxBullet);
        }
        if(gameObject.TryGetComponent(out IControlble componenet))
        {
            componenet.EnterInMachine(playerObjects);
        }
    }
}
