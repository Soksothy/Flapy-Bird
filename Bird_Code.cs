using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For handling UI updates

public class Bird_Code : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 5;
    public bool birdIsAlive = true;
    public GameObject gameOverText; // Reference to the Game Over text UI

    void Start()
    {
        myRigidbody.gravityScale = 1.5f;
        gameOverText.SetActive(false); // Initially hide Game Over text
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
        // Check if the bird goes out of bounds
        if (transform.position.y > 15 || transform.position.y < -15)
        {
            EndGame();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Trigger game over on collision
        EndGame();
    }
    
    void EndGame()
    {
        birdIsAlive = false;
        gameOverText.SetActive(true); // Show Game Over message
        Debug.Log("Game Over!");
        
        // Uncomment the following line to restart after a delay
        // Invoke("RestartGame", 2);
    }
    
    void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}