using Audio;
using Player;
using SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBaseClass<GameManager>
{
    public bool startTheGame;
    [SerializeField] private GameObject gameOver;
    
    private bool isGameOver;

    public bool IsGameOver => isGameOver;

    private void Start()
    {
        isGameOver = false;
    }
    
    /// <summary>
    /// Button click audio
    /// </summary>
    public void ButtonClick()
    {
        AudioManager.Instance.Play(ListSound.ButtonClick);
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
    /// Back to home
    /// </summary>
    public void BackToHome()
    {
        ButtonClick();
        SceneLoadTrigger.Instance.LoadScene("HomeScene");
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseGame()
    {
        ButtonClick();
        Time.timeScale = 0f;
    }
    
    /// <summary>
    /// Button click
    /// </summary>
    /// <param name="sceneName">Name of the scene</param>
    public void PlayGame(string sceneName)
    {
        ButtonClick();
        SceneLoadTrigger.Instance.LoadScene(sceneName);
    }
    
    /// <summary>
    /// Restart game
    /// </summary>
    public void RestartGame()
    {
        ButtonClick();
        // Load current scene
        SceneLoadTrigger.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeGame()
    {
        ButtonClick();
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Exit the game
    /// </summary>
    public void ExitGame()
    {
        ButtonClick();
        Application.Quit();
    }
}
