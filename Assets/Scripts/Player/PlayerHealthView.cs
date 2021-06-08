using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealthView : MonoBehaviour
    {
        #region Singleton

        private static PlayerHealthView instance;
        private const string LOG = nameof(PlayerHealthView);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static PlayerHealthView Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<PlayerHealthView>();
                    
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
        
        [SerializeField] private Sprite emptyLive;
        [SerializeField] private Image[] playerLivesImage;
        
        /// <summary>
        /// Update player lives
        /// </summary>
        /// <param name="playerLives">Value of player lives</param>
        public void UpdatePlayerLives(int playerLives)
        {
            switch (playerLives)
            {
                case 2:
                    playerLivesImage[2].sprite = emptyLive;
                    break;
                case 1:
                    playerLivesImage[1].sprite = emptyLive;
                    break;
                case 0:
                    playerLivesImage[0].sprite = emptyLive;
                    break;
            }
        }
    }
}