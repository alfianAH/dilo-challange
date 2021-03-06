using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerView : SingletonBaseClass<TimerView>
    {
        [SerializeField] private Text timerText;
        
        [Range(0, 59)]
        [SerializeField] private int defaultMinutes, 
            defaultSeconds;
        
        private TimerModel timerModel;
        
        private bool isCountingDown;
        
        public bool IsCountingDown
        {
            set => isCountingDown = value;
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            timerModel = new TimerModel
            {
                Minutes = defaultMinutes,
                Seconds = defaultSeconds
            };
            
            UpdateTimerText();
        }

        private void Update()
        {
            timerModel.CountDown(isCountingDown, () =>
            {
                isCountingDown = false;
                GameManager.Instance.GameOver();
            }, UpdateTimerText);
        }

        #endregion

        #region User Interface
        
        /// <summary>
        /// Update timer text in UI
        /// </summary>
        private void UpdateTimerText()
        {
            timerText.text = timerModel.Seconds <= 15 && timerModel.Minutes == 0
                ? $"{timerModel.Seconds + timerModel.Milliseconds:F}" 
                : $"{timerModel.Minutes:00} : {timerModel.Seconds:00}";
        }
        
        #endregion
    }
}