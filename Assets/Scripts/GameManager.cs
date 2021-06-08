using Player;
using SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager instance;
    private const string LOG = nameof(GameManager);
        
    /// <summary>
    /// Singleton method
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Find instance
                instance = FindObjectOfType<GameManager>();
                    
                // If instance is not found, ...
                if (instance == null)
                {
                    // Give log error
                    Debug.LogError($"{LOG} not found");
                }
            }

            return instance;
        }
    } 

    #endregion

    [SerializeField] private GameObject gameOver;
    
    private bool isGameOver;

    public bool IsGameOver => isGameOver;

    private void Start()
    {
        isGameOver = false;
    }
    
    /// <summary>
    /// Handle game over
    /// </summary>
    public void GameOver()
    {
        isGameOver = true;
        // Set high score
        ScoreManager.Instance.SetHighScore();
        gameOver.SetActive(true);
    }
    
    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    
    /// <summary>
    /// Restart game
    /// </summary>
    public void RestartGame()
    {
        // Load current scene
        SceneLoadTrigger.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
