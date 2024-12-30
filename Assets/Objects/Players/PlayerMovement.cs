using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    [SerializeField]
    private float speed = 150f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementInput = Vector2.zero;
    private Vector2 _smoothedMovementInput = Vector2.zero;
    private Vector2 _smoothedMovementVelocity = Vector2.zero;
    private PlayerGraphicsManager _playerGraphicsManager;
    private SpriteRenderer _spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerGraphicsManager = GetComponent<PlayerGraphicsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerGraphicsManager = GetComponentInChildren<PlayerGraphicsManager>();
    }

    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _smoothedMovementVelocity,
            0.05f
        );
        _rigidbody2D.linearVelocity = _smoothedMovementInput * speed * Time.fixedDeltaTime;
    }


    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();

        if (_playerGraphicsManager != null)
        {
            _playerGraphicsManager.SetPlayerGraphics(_movementInput);
        }
    }
}
