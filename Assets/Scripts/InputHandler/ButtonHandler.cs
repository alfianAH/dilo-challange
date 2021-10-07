using SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InputHandler
{
    public class ButtonHandler : MonoBehaviour
    {
        private GameManager gameManager;
        
        private void Awake()
        {
            gameManager = GameManager.Instance;
        }

        /// <summary>
        /// Back to home
        /// </summary>
        public void BackButton(string sceneName)
        {
            gameManager.ButtonClick();
            SceneLoadTrigger.Instance.LoadScene(sceneName);
        }
    
        /// <summary>
        /// Pause the game
        /// </summary>
        public void PauseGame()
        {
            gameManager.ButtonClick();
            Time.timeScale = 0f;
        }
        
        /// <summary>
        /// Button click
        /// </summary>
        /// <param name="sceneName">Name of the scene</param>
        public void PlayGame(string sceneName)
        {
            gameManager.ButtonClick();
            SceneLoadTrigger.Instance.LoadScene(sceneName);
        }
        
        /// <summary>
        /// Restart game
        /// </summary>
        public void RestartGame()
        {
            gameManager.ButtonClick();
            // Load current scene
            SceneLoadTrigger.Instance.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        /// <summary>
        /// Resume the game
        /// </summary>
        public void ResumeGame()
        {
            gameManager.ButtonClick();
            Time.timeScale = 1f;
        }
    
        /// <summary>
        /// Exit the game
        /// </summary>
        public void ExitGame()
        {
            gameManager.ButtonClick();
            Application.Quit();
        }
    }
}