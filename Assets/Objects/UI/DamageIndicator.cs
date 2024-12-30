using UnityEngine;
using TMPro;
public class DamageIndicator : MonoBehaviour
{
    float time = 0.5f;
    float currentTime = 0f;
    public float damage = 0f;

    private TMP_Text message;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        message = GetComponent<TMP_Text>();
        message.text = damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= time)
        {
            Destroy(gameObject);
        }
    }
}

