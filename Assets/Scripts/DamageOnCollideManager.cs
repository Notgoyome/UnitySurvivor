using UnityEngine;

public class DamageOnCollideManager : MonoBehaviour
{
    [SerializeField] 
    public int knockbackForce = 5;
    public float attack_rate = 1f;
    public int damage = 5;

    private float nextAttackTime = 0f;
    private bool canAttack = true;
    
    
    public Rigidbody2D _rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
        {
            if (nextAttackTime >= attack_rate)
            {
                canAttack = true;
                nextAttackTime = 0f;
            }
            else
            {
                nextAttackTime += Time.deltaTime;
            }
        }
        
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && canAttack)
        {
            var healthComponent = other.gameObject.GetComponent<HealthComponent>();
            if (healthComponent != null) {
                nextAttackTime = 0f;
                canAttack = false;
                healthComponent.TakeDamage(10);
                Debug.Log("Player took damage");
            }
        }
    }

}
