using UnityEngine;

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

        private const string HIGH_SCORE = "high_score";
        
        private int score;
        private int highScore;

        public int Score => score;
        public int HighScore => highScore;

        /// <summary>
        /// Add score by value
        /// </summary>
        /// <param name="value">Value to add the score</param>
        public void AddScore(int value)
        {
            score += value;
        }
        
        /// <summary>
        /// Set high score in player prefs
        /// </summary>
        public void SetHighScore()
        {
            // If there is high score key in player prefs, ...
            if (PlayerPrefs.HasKey(HIGH_SCORE))
            {
                // If current score is greater than high score, ...
                if (score > PlayerPrefs.GetInt(HIGH_SCORE))
                {
                    Debug.Log("Break record");
                    // Set new high score
                    highScore = score;
                    PlayerPrefs.SetInt(HIGH_SCORE, highScore);
                }
            }
            else // If there is no key, ...
            {
                // Set new high score
                Debug.Log("New record");
                highScore = score;
                PlayerPrefs.SetInt(HIGH_SCORE, highScore);
            }
        }
    }
}
