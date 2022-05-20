using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateShoot : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private SwitchCamera switchCamera;
    [SerializeField] private HitMaker hitMaker;

    public void Shoot(float damage)
    {
        GameObject obj = switchCamera.GetObjectInCenterCamera(500);
        if (obj != null && obj.TryGetComponent(out EnemyHP component))
        {
            component.TakeDamage(damage);
            hitMaker.Hit();
        }
    }
}
