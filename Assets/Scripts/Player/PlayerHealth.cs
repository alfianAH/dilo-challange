using Audio;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: MonoBehaviour
    {
        #region Singleton

        private static PlayerHealth instance;
        private const string LOG = nameof(PlayerHealth);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static PlayerHealth Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<PlayerHealth>();
                    
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

        [HideInInspector] public int playerLives = 3;
        
        public void CheckLives()
        {
            // If player lives hits 0, ...
            if (playerLives == 0)
            {
                // Game over
                GameManager.Instance.GameOver();
                AudioManager.Instance.Play(ListSound.Die);
            }
        }
    }
}
