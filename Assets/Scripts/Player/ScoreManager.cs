using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ScoreManager : MonoBehaviour
    {
        #region Singleton

        private static ScoreManager instance;
        private const string LOG = nameof(ScoreManager);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<ScoreManager>();
                    
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

        [SerializeField] private Text scoreText;
        private int score;

        /// <summary>
        /// Add score by value
        /// </summary>
        /// <param name="value">Value to add the score</param>
        public void AddScore(int value)
        {
            score += value;
            scoreText.text = score.ToString();
        }
    }
}
