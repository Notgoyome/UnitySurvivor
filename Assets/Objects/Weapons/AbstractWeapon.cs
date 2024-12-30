using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{

    public WeaponStats weaponStats;

    protected virtual void Start()
    {
        Invoke("Shoot", weaponStats.fireRate);
    }

    public abstract void Shoot();

}
