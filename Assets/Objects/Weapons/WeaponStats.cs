using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Scriptable Objects/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public string weaponName;

    public float fireRate = 1f;

    public float speed = 120f;

    public float damage = 10f;

    public GameObject bulletPrefab;

    public GameObject weaponPrefab;

    public int level = 1;

    public List<Upgrade> upgrades = new List<Upgrade>();

    public void levelUp()
    {
        level++;
        if (upgrades.Count == 0)
        {
            return;
        }
        Debug.Log("Upgrading weapon");
        Debug.Log("Upgrades: " + upgrades.Count);
        Upgrade upgrade = upgrades[0];
        upgrades.RemoveAt(0);
        switch (upgrade.upgradeName)
        {
            case "fireRate":
                fireRate += upgrade.upgradeValue;
                break;
            case "speed":
                speed += upgrade.upgradeValue;
                break;
            case "damage":
                damage += upgrade.upgradeValue;
                break;
            default:
                break;
        }
        Debug.Log("Damage: " + damage);
        Debug.Log("Speed: " + speed);
        Debug.Log("Fire rate: " + fireRate);
    }

    public Upgrade getUpgrade()
    {
        if (upgrades.Count == 0)
        {
            Debug.LogWarning("Upgrades: " + upgrades.Count);
            return null;
        }
        return upgrades[0];
    }
}


[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public float upgradeValue;
}