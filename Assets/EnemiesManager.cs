using UnityEngine;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;
    
    [SerializeField]
    private float distance = 6f;

    [SerializeField]
    private float frequence = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("EnemiesManager started");
        InvokeRepeating("SpawnEnemy", 0, frequence);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float angle = 0;

    void SpawnEnemy()
    {
        foreach (var enemy in enemies)
        {
            angle = Random.Range(0, 360);
            float random_angle = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(random_angle) * distance;
            float y = Mathf.Sin(random_angle) * distance;

            Vector3 position = new Vector3(x, y, 0);
            Instantiate(enemy, position + transform.position, Quaternion.identity);
        }
    }
}
