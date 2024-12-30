using UnityEngine;
using UnityEngine.Events;
public class HealthComponent : MonoBehaviour
{

    [SerializeField]
    private float _maxHealth = 100f;

    [SerializeField]
    public UnityEvent onDeath;

    private float _currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
        
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        onDeath.Invoke();
    }

    public void killObject()
    {
        Destroy(gameObject);
    }
}
