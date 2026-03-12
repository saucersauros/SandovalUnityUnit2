using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float top = 30;
    private float bot = -10;


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
