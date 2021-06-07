using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;

        private Rigidbody2D playerRigidbody;
        
        #region MonoBehaviour methods

        private void Start()
        {
            // Get component
            playerRigidbody = GetComponent<Rigidbody2D>();
            
            // Add force to player
            playerRigidbody.AddForce(Vector2.one * speed, ForceMode2D.Impulse);
        }

        private void Update()
        {
            Debug.Log($"Velocity: {playerRigidbody.velocity}");
        }

        #endregion
    }
}
