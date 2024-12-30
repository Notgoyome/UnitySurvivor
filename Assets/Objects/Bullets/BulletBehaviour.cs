using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]

    public float speed = 10f;

    [SerializeField]

    public Vector2 direction;

    [SerializeField]
    public float damage;

    [SerializeField]
    private DamageIndicator _damageIndicator;

    private Rigidbody2D _rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        _rigidbody2D.linearVelocity =  speed * Time.deltaTime * direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            HealthComponent healthComponent = other.GetComponent<HealthComponent>();
            healthComponent.TakeDamage(damage);
            DamageIndicator damageIndicator = Instantiate(_damageIndicator, other.transform.position, Quaternion.identity);
            damageIndicator.damage = damage;
            Destroy(gameObject);
        }
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }
}
