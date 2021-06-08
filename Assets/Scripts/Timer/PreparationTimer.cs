using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class PreparationTimer : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        [Range(0, 59)]
        [SerializeField] private int defaultMinutes, 
            defaultSeconds;
        
        private TimerModel timerModel;
        
        private bool isCountingDown;

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            isCountingDown = true;
            timerModel = new TimerModel
            {
                Minutes = defaultMinutes,
                Seconds = defaultSeconds
            };
            AudioManager.Instance.Play(ListSound.CountDown);
            
            UpdateTimerText();
        }
        
        // Update is called once per frame
        private void Update()
        {
            timerModel.CountDown(isCountingDown, () =>
            {
                isCountingDown = false;
                TimerView.Instance.IsCountingDown = true;
                gameObject.SetActive(false);
            }, UpdateTimerText);
        }
        
        #endregion

        #region User Interface
        
        /// <summary>
        /// Update timer text in UI
        /// </summary>
        private void UpdateTimerText()
        {
            timerText.text = $"{timerModel.Seconds}";
        }
        
        #endregion
    }
}