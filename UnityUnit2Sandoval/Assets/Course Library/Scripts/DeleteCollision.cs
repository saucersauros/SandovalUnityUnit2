using UnityEngine;
using UnityEngine.UI;

public class DeleteCollision : MonoBehaviour
{
    private GameManager1 gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.AddLives(-1);
        Destroy(gameObject);
    } else if (other.CompareTag("Animal"))
    {
    gameManager.AddScore(5);
    Destroy(gameObject);
    Destroy(other.gameObject);
    }


}


