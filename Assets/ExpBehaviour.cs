using UnityEngine;

public class ExpBehaviour : MonoBehaviour
{

    [SerializeField]
    public int xp = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DataManager.instance.updateXp(xp);
            Destroy(gameObject);
        }
    }
}
