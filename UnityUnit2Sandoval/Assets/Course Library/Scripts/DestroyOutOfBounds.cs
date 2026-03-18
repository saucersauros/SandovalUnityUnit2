using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30; 
    private float lowerBound = 110; 
    private float sideBound = 30;
    private GameManager1 gameManager;

    void Start() 
    { 
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>(); 
    }


    void Update()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}

