using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private List<Transform> _enemiesPosition = new List<Transform>();
    public Transform nearestEnemy;

    public float distance_max = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAllEnemies();
        nearestEnemy = GetNearestEnemy();
    }

    void GetAllEnemies()
    {
        _enemiesPosition.Clear();
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemies")) {
            _enemiesPosition.Add(enemy.transform);
        }
    }

    Transform GetNearestEnemy()
    {
        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        foreach (var enemy in _enemiesPosition) {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < minDistance) {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
        if (minDistance > distance_max) {
            return null;
        }
        return nearestEnemy;
    }       
}
