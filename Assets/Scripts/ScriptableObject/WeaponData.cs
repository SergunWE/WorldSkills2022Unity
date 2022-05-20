using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Data")]
public class WeaponData : ScriptableObject
{
    public int id;

    public int clipBullet;
    public int maxBullet;

    public float shootTime;
    public float reloadTime;

    public float damage;

    public AudioClip shootAudio;
    public AudioClip reloadAudio;

    public GameObject model;

    public float zoom;
}
