using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Hit by food — award a point
        if (other.CompareTag("Food"))
        {
            GameManager.Instance?.AddScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Hit the player — lose a life
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.LoseLife();
            Destroy(gameObject);
        }
    }
}
