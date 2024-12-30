using UnityEngine;

public class WeaponBehaviour : AbstractWeapon
{
    public EnemyDetector enemyDetector;
    
    public override void Shoot()
    {
        if (!enemyDetector.nearestEnemy)
        {
            Invoke("Shoot", weaponStats.fireRate);
            return;
        }
        Vector2 direction = enemyDetector.nearestEnemy.position - transform.position;
        Debug.Log("Shooting");
        GameObject bullet = Instantiate(weaponStats.bulletPrefab, transform.position, Quaternion.identity);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.direction = direction.normalized;
        bulletBehaviour.speed = weaponStats.speed;
        bulletBehaviour.damage = weaponStats.damage;
        Invoke("Shoot", weaponStats.fireRate);
    }

    void Update()
    {
    }
}
