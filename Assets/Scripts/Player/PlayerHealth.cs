using Audio;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: SingletonBaseClass<PlayerHealth>
    {
        [HideInInspector] public int playerLives = 3;
        
        public void CheckLives()
        {
            // If player lives hits 0, ...
            if (playerLives == 0)
            {
                // Game over
                GameManager.Instance.GameOver();
                AudioManager.Instance.Play(ListSound.Die);
            }
        }
    }
}
