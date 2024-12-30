using UnityEngine;

public class TagFollowerMovement : MonoBehaviour
{
    [SerializeField]
    private string tagToFollow = "Player";
    [SerializeField]
    private float speed = 30f;

    private Rigidbody2D _rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Player player;
        if (GameObject.FindGameObjectWithTag(tagToFollow).TryGetComponent(out player))
        {
            Vector2 direction = player.transform.position - transform.position;
            _rigidbody2D.linearVelocity =direction.normalized * speed * Time.fixedDeltaTime;
        }
    }
}
