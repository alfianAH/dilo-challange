using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text timerText;

        private void Update()
        {
            timerText.text = GetTime(TimerManager.Instance.GetRemainingTime());
        }
        
        /// <summary>
        /// Get time in minute:second format
        /// </summary>
        /// <param name="timeRemaining">Remaining time</param>
        /// <returns>Returns $"{minute} : {second}"</returns>
        private string GetTime(float timeRemaining)
        {
            int minute = Mathf.FloorToInt(timeRemaining / 60);
            int second = Mathf.FloorToInt(timeRemaining % 60);

            return $"{minute:00} : {second:00}";
        }
    }
}