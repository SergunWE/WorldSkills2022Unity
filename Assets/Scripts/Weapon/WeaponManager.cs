using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    [SerializeField] private Transform fpsWeapons;
    [SerializeField] private Transform tpsWeapons;

    private GameObject[] fpsModels;
    private GameObject[] tpsModels;

    private GameObject fpscurrentweapon;
    private GameObject tpscurrentweapon;

    private void Awake()
    {
        int weaponsCount = fpsWeapons.childCount;
        fpsModels = new GameObject[weaponsCount];
        tpsModels = new GameObject[weaponsCount];
        for (int i = 0; i < weaponsCount; i++)
        {
            fpsModels[i] = fpsWeapons.GetChild(i).gameObject;
        }
        for (int i = 0; i < weaponsCount; i++)
        {
            tpsModels[i] = tpsWeapons.GetChild(i).gameObject;
        }

    }

    private void Start()
    {
        fpscurrentweapon = fpsModels[weaponData.id];
        fpscurrentweapon.SetActive(true);

        tpscurrentweapon = tpsModels[weaponData.id];
        tpscurrentweapon.SetActive(true);
    }

    public void UpdateWeaponView(WeaponData weaponData)
    {
        this.weaponData = weaponData;

        if(weaponData == null)
        {
            fpscurrentweapon.SetActive(false);
            return;
        }

        fpscurrentweapon.SetActive(false);
        fpscurrentweapon = fpsModels[weaponData.id];
        fpscurrentweapon.SetActive(true);

        tpscurrentweapon.SetActive(false);
        tpscurrentweapon = tpsModels[weaponData.id];
        tpscurrentweapon.SetActive(true);
    }

    public WeaponData WeaponData
    {
        get => weaponData;
        set => weaponData = value;
    }
}
