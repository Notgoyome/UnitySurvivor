using UnityEngine;

public class PlayerGraphicsManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerGraphics(Vector2 movementInput)
    {
        if (movementInput.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (movementInput.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
