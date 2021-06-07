
using Player;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleManager : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                ScoreManager.Instance.AddScore(1);
            }
        }
    }
}
