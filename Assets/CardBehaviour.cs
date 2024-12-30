using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    protected WeaponStats weaponStats;

    public void setWeaponStats(WeaponStats weaponStats)
    {
        this.weaponStats = weaponStats;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeWeapon()
    {
        // Debug.Log("Upgrading weapon");
        // weaponStats.levelUp();
    }
}
