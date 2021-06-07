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

        #region MonoBehaviour Methods

        private void Start()
        {
            // Get component
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Debug.Log($"Velocity: {playerRigidbody.velocity}");
        }

        #endregion

        #region Movement
        
        /// <summary>
        /// Handle player movement
        /// </summary>
        /// <param name="horizontal">Horizontal axis</param>
        /// <param name="vertical">Vertical axis</param>
        public void Move(float horizontal, float vertical)
        {
            
        }

        #endregion
    }
}
