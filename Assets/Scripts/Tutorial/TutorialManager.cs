using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("Tutorial")]
        [SerializeField] private TutorialObjects[] tutorialObjects;
        [SerializeField] private Text tutorialText;
        [SerializeField] private Transform player;
        
        [Header("Tutorial - Move the player with mouse")]
        [SerializeField] private Toggle movementTogle;
        
        [Header("Pop up")]
        [SerializeField] private Transform popUpTransform;
        [SerializeField] private float popUpShowDuration = 10f;
        private float popUpShowDurationCounter;
        private bool showPopUp = true;
        
        private int popUpIndex;

        private void Update()
        {
            // Pop Up animation
            if (popUpShowDurationCounter > 0)
            {
                // Decrease duration when pop up duration is greater than 0
                popUpShowDurationCounter -= Time.unscaledDeltaTime;
                popUpTransform.localScale = Vector3.LerpUnclamped(popUpTransform.localScale, Vector3.one, 0.5f);
            }
            else
            {
                popUpTransform.localScale = Vector2.LerpUnclamped(popUpTransform.localScale, Vector2.right, 0.5f);
            }

            TutorialFlow();
        }
            
        /// <summary>
        /// Tutorial flow from the first tutorial until the last
        /// </summary>
        private void TutorialFlow()
        {
            switch (popUpIndex)
            {
                // Move the player with keyboard
                case 0:
                    CheckTutorial(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
                                  Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
                                  Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ||
                                  Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
                    break;
                
                // Move the player with mouse
                case 1:
                    CheckTutorial(!movementTogle.isOn && popUpShowDurationCounter < 0);
                    break;
                
                // Eat the box and show the score
                case 2:
                    movementTogle.isOn = true;
                    CheckTutorial(ScoreManager.Instance.Score > 0);
                    break;
                
                // Show the boundaries and player lives
                case 3:
                    CheckTutorial(PlayerHealth.Instance.playerLives < 3);
                    break;
                
                // Show the timer and play until finish
                case 4:
                    ShowTutorial();
                    GameManager.Instance.startTheGame = false;
                    popUpIndex++;
                    break;
            }
        }

        private void ResetPlayerPosition()
        {
            player.position = Vector2.zero;
        }
        
        /// <summary>
        /// Check tutorial if completed
        /// </summary>
        /// <param name="condition">Tutorial requirements</param>
        private void CheckTutorial(bool condition)
        {
            ShowTutorial();

            if (condition)
            {
                ResetPlayerPosition();
                ShowNextTutorial();
            }
        }
        
        /// <summary>
        /// Show next tutorial by:
        /// 1. Make showPopUp to true
        /// 1. Increasing pop up index
        /// </summary>
        private void ShowNextTutorial()
        {
            showPopUp = true;
            popUpIndex++;
        }
        
        /// <summary>
        /// SHow tutorial pop up text and set active all the objects
        /// </summary>
        private void ShowTutorial()
        {
            if (!showPopUp) return;
            
            ShowTutorialPopUp(tutorialObjects[popUpIndex].tutorialPopUp);
            ShowTutorialObjects(tutorialObjects[popUpIndex].gameObjects);
            
            showPopUp = false;
        }
        
        /// <summary>
        /// Set active all tutorial objects
        /// </summary>
        /// <param name="tutorialObjects">Tutorial objects</param>
        private void ShowTutorialObjects(GameObject[] tutorialObjects)
        {
            if (tutorialObjects == null) return;

            foreach (GameObject tutorialObject in tutorialObjects)
            {
                tutorialObject.SetActive(true);
            }
        }

        /// <summary>
        /// Show tutorial pop up
        /// </summary>
        /// <param name="tutorialText">Tutorial text</param>
        private void ShowTutorialPopUp(string tutorialText)
        {
            this.tutorialText.text = tutorialText;
            popUpShowDurationCounter = popUpShowDuration;
            popUpTransform.localScale = Vector2.right;
        }
    }
    
    [Serializable]
    public class TutorialObjects
    {
        public string name;
        [TextArea(3, 5)]
        public string tutorialPopUp;
        public GameObject[] gameObjects;
    }
}
