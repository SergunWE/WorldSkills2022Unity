using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private CalculateShoot calculateShoot;
    [SerializeField] private WeaponSound weaponSound;

    [SerializeField] private Animation fpsAnimation;

    private int _clipBullet;
    private int _maxBullet;

    private bool _canShoot = true;
    
    private WeaponData weaponData => weaponManager.WeaponData;

    private void Start()
    {
        _clipBullet = weaponData.clipBullet;
        _maxBullet = weaponData.maxBullet;
    }

    private void Shoot()
    {
        if (!_canShoot) return;
        if(_clipBullet > 0)
        {
            _clipBullet--;
            StopAllCoroutines();
            StartCoroutine(ShootDelay());
            calculateShoot.Shoot(weaponData.damage);
            weaponSound.PlayShootSound();
            fpsAnimation.Stop();
            //animation.GetClip("WeaponShoot")
            fpsAnimation["WeaponShoot"].speed = fpsAnimation["WeaponShoot"].length / weaponData.shootTime;
            fpsAnimation.Play("WeaponShoot");
            Debug.Log(_clipBullet + "/" + _maxBullet);
            return;
        }
        Reload();
    }

    private void Reload()
    {
        if (!_canShoot) return;
        if(_maxBullet > 0 && _clipBullet < _maxBullet)
        {
            Debug.Log("reload");
            weaponSound.PlayReloadSound();
            fpsAnimation.Stop();
            fpsAnimation["WeaponReload"].speed = fpsAnimation["WeaponReload"].length / weaponData.reloadTime;
            fpsAnimation.Play("WeaponReload");
            StopAllCoroutines();
            StartCoroutine(ReloadDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        _canShoot = false;
        yield return new WaitForSeconds(weaponData.shootTime);
        _canShoot = true;
    }

    private IEnumerator ReloadDelay()
    {
        _canShoot = false;
        yield return new WaitForSeconds(weaponData.reloadTime);
        if(_maxBullet > weaponData.clipBullet - _clipBullet)
        {
            _maxBullet -= weaponData.clipBullet - _clipBullet;
            _clipBullet = weaponData.clipBullet;
        }
        else
        {
            _maxBullet = 0;
            _clipBullet += _maxBullet;
        }
        _canShoot = true;
        Debug.Log(_clipBullet + "/" + _maxBullet);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Shoot();
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Reload();
        }
    }

    public void SetBullets(int clipBullet, int maxBullet)
    {
        _clipBullet = clipBullet;
        _maxBullet = maxBullet;
    }

    public int ClipBullet => _clipBullet;
    public int MaxBullet => _maxBullet;
}
