using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private WeaponManager weaponManager;

    public void PlayShootSound()
    {
        audioSource.clip = weaponManager.WeaponData.shootAudio;
        audioSource.Play();
    }

    public void PlayReloadSound()
    {
        audioSource.clip = weaponManager.WeaponData.reloadAudio;
        audioSource.Play();
    }
}
