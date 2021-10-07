using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneLoading
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Text loadingValueText;
        
        private const float WAIT_SECONDS = 2.0f;
        
        private void Start()
        {
            loadingValueText.text = "0%";
            StartCoroutine(LoadSceneAsync());
        }
        
        /// <summary>
        /// Load scene asynchronously
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadSceneAsync()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(WAIT_SECONDS);
            
            // Load scene asynchronously
            AsyncOperation loadScene = 
                SceneManager.LoadSceneAsync(LoadingData.SceneName);
            
            while (!loadScene.isDone)
            {
                loadingValueText.text = $"{loadScene.progress * 100:00}%";
                yield return null;
            }
        }
    }
}