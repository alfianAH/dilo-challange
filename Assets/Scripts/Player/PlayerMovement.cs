using Audio;
using Obstacle;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : SingletonBaseClass<PlayerMovement>
    {
        [SerializeField] private float speed = 5.0f;

        private Rigidbody2D playerRigidbody;
        private Vector3 movement;

        #region MonoBehaviour Methods

        private void Start()
        {
            // Get component
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // If player collide with boundary, ...
            if (other.gameObject.CompareTag("Boundary"))
            {
                AudioManager.Instance.Play(ListSound.Warning); // Play warning
                PlayerHealth.Instance.playerLives -= 1; // Minus the live
                PlayerHealthView.Instance.UpdatePlayerLives(PlayerHealth.Instance.playerLives); // Update the lives
                PlayerHealth.Instance.CheckLives(); // Check for live
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                other.gameObject.SetActive(false);
                AudioManager.Instance.Play(ListSound.PointObtained);
                ScoreManager.Instance.AddScore(1);
                StartCoroutine(ObstacleSpawner.Instance.RespawnObstacle());
            }
        }

        #endregion

        #region Movement
        
        /// <summary>
        /// Handle player movement
        /// </summary>
        /// <param name="horizontal">Horizontal axis value</param>
        /// <param name="vertical">Vertical axis value</param>
        public void Move(float horizontal, float vertical)
        {
            movement.Set(horizontal, vertical, 0);
            
            // Normalized movement to get 0-1
            movement = movement.normalized * (speed * Time.deltaTime);
            
            // Move to position
            playerRigidbody.MovePosition(transform.position + movement);
        }

        #endregion
    }
}
