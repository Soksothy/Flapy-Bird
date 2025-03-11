using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public Text scoreText; // UI Text to display score
    private int score = 0; // Score counter

    void Awake()
    {
        // Ensure only one ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score++; // Increment the score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score display
            Debug.Log("Score updated to: " + score);
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the ScoreManager!");
        }
    }
}