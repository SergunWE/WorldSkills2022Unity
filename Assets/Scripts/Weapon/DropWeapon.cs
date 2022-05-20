using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour, IDropableWeapon
{
    [SerializeField] private WeaponData weaponData;

    private int clipBullet;
    private int maxBullet;

    private GameObject model;

    private void Start()
    {
        if(weaponData != null)
        model = Instantiate(weaponData.model, transform);
        clipBullet = weaponData.clipBullet;
        maxBullet = weaponData.maxBullet;
    }

    public void SetWeaponData(WeaponData weaponData, int clipBullet, int maxBullet)
    {
        if(weaponData == null)
        {
            Destroy(this.gameObject);
            return;
        }
        if(model!=null)
        {
            Destroy(model);
        }
        this.weaponData = weaponData;
        model = Instantiate(weaponData.model, transform);
        this.clipBullet = clipBullet;
        this.maxBullet = maxBullet;
    }

    public WeaponData WeaponData()
    {
        return weaponData;
    }

    public int GetClipBullet()
    {
        return clipBullet;
    }

    public int GetMaxBullet()
    {
        return maxBullet;
    }
}
