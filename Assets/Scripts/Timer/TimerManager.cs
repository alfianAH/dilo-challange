using UnityEngine;

namespace Timer
{
    public class TimerManager : MonoBehaviour
    {
        #region Singleton

        private static TimerManager instance;
        private const string LOG = nameof(TimerManager);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static TimerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<TimerManager>();
                    
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
        
        [SerializeField] private int duration;

        private float time;

        #region MonoBehaviour Methods

        private void Start()
        {
            time = 0;
        }

        private void Update()
        {
            // If game is already over, return
            if (GameManager.Instance.IsGameOver) return;
            
            // If time is greater than duration, ...
            if (time > duration)
            {
                // Game Over
                GameManager.Instance.GameOver();
                return;
            }
            
            time += Time.deltaTime;
        }

        #endregion

        /// <summary>
        /// Get remaining time in game
        /// </summary>
        /// <returns>Returns fixed duration - current time</returns>
        public float GetRemainingTime()
        {
            return duration - time;
        }
    }
}
