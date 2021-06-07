using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Singleton

        private static PlayerMovement instance;
        private const string LOG = nameof(PlayerMovement);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static PlayerMovement Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<PlayerMovement>();
                    
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

        [SerializeField] private float speed = 5.0f;

        private Rigidbody2D playerRigidbody;
        private Vector3 movement;

        #region MonoBehaviour Methods

        private void Start()
        {
            // Get component
            playerRigidbody = GetComponent<Rigidbody2D>();
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
