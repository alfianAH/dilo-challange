using UnityEngine;

namespace Player
{
    public class ScoreManager : SingletonBaseClass<ScoreManager>
    {
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
                int previousHighScore = PlayerPrefs.GetInt(HIGH_SCORE);
                
                // If current score is greater than high score, ...
                if (score > previousHighScore)
                {
                    // Set new high score
                    highScore = score;
                    PlayerPrefs.SetInt(HIGH_SCORE, highScore);
                }
                else // Else, ...
                {
                    // Keep the highScore the same as previousHighScore
                    highScore = previousHighScore;
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
