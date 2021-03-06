using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text score;
        [SerializeField] private Text highScore;
        [SerializeField] private Text gameOverScore;

        private void Update()
        {
            score.text = $"Score: {ScoreManager.Instance.Score.ToString()}";
            
            if(gameOverScore != null || highScore != null)
            {
                gameOverScore.text = $"Score: {ScoreManager.Instance.Score.ToString()}";
                highScore.text = $"High Score: {ScoreManager.Instance.HighScore.ToString()}";
            }
        }
    }
}