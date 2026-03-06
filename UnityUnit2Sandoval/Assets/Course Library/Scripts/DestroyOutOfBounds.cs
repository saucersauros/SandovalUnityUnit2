using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float top = 30;
    private float bot = -10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > top)
        {
            Destroy(gameObject);
        } else if (transform.position.z < bot)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
