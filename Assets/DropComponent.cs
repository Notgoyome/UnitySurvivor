using UnityEngine;

public class DropComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject dropPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }
}
