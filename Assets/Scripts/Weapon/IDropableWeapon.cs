
public interface IDropableWeapon
{
    WeaponData WeaponData();
    void SetWeaponData(WeaponData weaponData, int clipBullet, int maxBullet);
    int GetClipBullet();
    int GetMaxBullet();
}
