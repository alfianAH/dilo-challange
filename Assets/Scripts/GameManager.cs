using Audio;
using Player;
using UnityEngine;

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
}
