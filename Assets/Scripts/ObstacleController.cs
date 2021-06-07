using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer boxPrefab;
    [SerializeField] private SpriteRenderer upBoundary, 
        downBoundary, 
        rightBoundary,
        leftBoundary;
    
    [SerializeField] private int maxBox = 5;

    private int generatedBox;
    
    #region MonoBehaviour Methods

    private void Start()
    {
        // Generate random number of generated boxes
        generatedBox = Random.Range(1, maxBox);
        
        GenerateBoxes();
    }

    #endregion

    #region Generate
    
    /// <summary>
    /// Generate box at random position
    /// </summary>
    private void GenerateBoxes()
    {
        // Generate as many as generatedBox
        for (int i = 0; i < generatedBox; i++)
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
            
            // Duplicate prefab
            Instantiate(boxPrefab, new Vector3(x, y),
                Quaternion.identity, transform);
        }
    }

    #endregion
}
