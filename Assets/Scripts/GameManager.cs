using UnityEngine;

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

    private bool isGameOver;

    public bool IsGameOver => isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
