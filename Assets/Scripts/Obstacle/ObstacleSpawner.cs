using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        #region Singleton

        private static ObstacleSpawner instance;
        private const string LOG = nameof(ObstacleSpawner);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static ObstacleSpawner Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<ObstacleSpawner>();
                    
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
        
        [SerializeField] private SpriteRenderer obstaclePrefab;
        [SerializeField] private SpriteRenderer upBoundary, 
            downBoundary, 
            rightBoundary,
            leftBoundary;
    
        [SerializeField] private int maxBox = 5;

        private PlayerMovement playerMovement;
        
        private readonly List<GameObject> obstaclePool = new List<GameObject>();

        private float respawnSeconds = 3.0f;
        private float spawnDistanceLimit = 1.0f;
        private int generatedBox;
        
        #region MonoBehaviour Methods

        private void Awake()
        {
            playerMovement = PlayerMovement.Instance;
        }

        private void Start()
        {
            // Generate random number of generated boxes
            generatedBox = Random.Range(1, maxBox);
            
            GenerateInitBoxes();
        }
        
        #endregion

        #region Generate
        
        /// <summary>
        /// Find random position for obstacle
        /// </summary>
        /// <returns>Returns random x, y in Vector3</returns>
        private Vector3 FindRandomPosition()
        {
            Vector3 result;
            
            while(true)
            {
                // Get minimum X axis
                float minX = leftBoundary.transform.position.x + leftBoundary.bounds.size.x;
                // Get maximum X axis
                float maxX = rightBoundary.transform.position.x - rightBoundary.bounds.size.x;
                // Get random position at minimum and maximum X
                float x = Random.Range(minX, maxX);

                // Get minimum Y axis
                float minY = upBoundary.transform.position.y - upBoundary.bounds.size.y;
                // Get maximum Y axis
                float maxY = downBoundary.transform.position.y + downBoundary.bounds.size.y;
                // Get random position at minimum and maximum Y
                float y = Random.Range(minY, maxY);
                
                result = new Vector3(x, y);
                
                // Check distance between player and obstacle's position
                float obstacleDistance = Vector3.Distance(playerMovement.transform.position, result);
                // If it's greater than spawnDistanceLimit, then go out from loop
                if (obstacleDistance > spawnDistanceLimit)
                {
                    break;
                }
            }

            return result;
        }
        
        /// <summary>
        /// Make obstacle by looking at the pool first
        /// If there are no available obstacles, create new one
        /// </summary>
        /// <returns>Returns obstacle from pool, else new one</returns>
        private GameObject CreateOrFindObstacle()
        {
            // Find inactive obstacle in hierarchy
            GameObject obstacle = obstaclePool.Find(o => !o.gameObject.activeSelf);

            if (obstacle == null)
            {
                Vector3 randomPosition = FindRandomPosition();
                obstacle = Instantiate(obstaclePrefab, randomPosition,
                    Quaternion.identity, transform).gameObject;
                
                obstaclePool.Add(obstacle);
            }

            return obstacle;
        }

        /// <summary>
        /// Generate initial boxes at random position
        /// </summary>
        private void GenerateInitBoxes()
        {
            // Generate as many as generatedBox
            for (int i = 0; i < generatedBox; i++)
            {
                Vector3 randomPosition = FindRandomPosition();
                // Duplicate prefab
                GameObject obstacle = Instantiate(obstaclePrefab, randomPosition,
                    Quaternion.identity, transform).gameObject;
                
                obstaclePool.Add(obstacle);
            }
        }
        
        /// <summary>
        /// Respawn obstacle after being obtained by player
        /// </summary>
        /// <returns>Wait for 3 seconds</returns>
        public IEnumerator RespawnObstacle()
        {
            yield return new WaitForSeconds(respawnSeconds);

            GameObject respawnObstacle = CreateOrFindObstacle();
            respawnObstacle.transform.position = FindRandomPosition();
            respawnObstacle.SetActive(true);
        }
        
        #endregion
    }
}
