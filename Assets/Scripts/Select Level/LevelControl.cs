using SceneLoading;
using UnityEngine;
using UnityEngine.UI;

namespace Select_Level
{
    public class LevelControl : MonoBehaviour
    {
        [SerializeField] private Text levelName;
        [SerializeField] private Button playButton;
        
        private LevelConfig config;
        
        private void Start()
        {
            // Add listener to play button
            playButton.onClick.AddListener(() =>
            {
                SceneLoadTrigger.Instance.LoadScene(config.sceneName);
            });
        }
        
        /// <summary>
        /// Set level configuration
        /// </summary>
        /// <param name="configuration">Level configuration</param>
        public void SetConfig(LevelConfig configuration)
        {
            config = configuration;

            levelName.text = $"{config.name}";
        }
    }
}