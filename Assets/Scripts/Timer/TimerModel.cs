using System;
using UnityEngine;

namespace Timer
{
    [Serializable]
    public class TimerModel
    {
        private float milliseconds;
        private int seconds, minutes;

        #region GETTER_SETER
        
        public float Milliseconds
        {
            get => milliseconds;
            set => milliseconds = value;
        }
        
        public int Seconds
        {
            get => seconds;
            set => seconds = value;
        }
        
        public int Minutes
        {
            get => minutes;
            set => minutes = value;
        }
        
        #endregion

        #region Count Down

        /// <summary>
        /// Count down
        /// </summary>
        /// <param name="isCountingDown"></param>
        /// <param name="timeIsUp">Events after time is up</param>
        /// <param name="updateTimerText">Method to update timer text</param>
        public void CountDown(bool isCountingDown, Action timeIsUp, Action updateTimerText)
        {
            if(isCountingDown)
            {
                milliseconds += Time.deltaTime;
                
                if (milliseconds >= 1.0f)
                {
                    milliseconds -= 1.0f;

                    // If time is not up, ...
                    if (seconds > 0 || minutes > 0)
                    {
                        seconds--; // Decrease seconds
                        if (seconds < 0.0f)
                        {
                            seconds = 59; // Repeat seconds
                            minutes--; // Decrease minutes;
                        }
                    }
                    else // If time is up, ...
                    {
                        timeIsUp();
                    }
                }
                
                updateTimerText();
            }
        }
        #endregion
    }
}