using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int lives = 3;
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("Lives = " + lives);
        Debug.Log("Score = " + score);
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score = " + score);
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Lives = " + lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}