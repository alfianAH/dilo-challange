using System;
using UnityEngine;

namespace Select_Level
{
    public class SelectLevelManager : MonoBehaviour
    {
        public LevelConfig[] levelConfigs;
        [SerializeField] private Transform levelParent;
        [SerializeField] private LevelControl levelHolderPrefab;

        #region MonoBehaviour Methods

        private void Start()
        {
            AddAllLevels();
        }

        #endregion

        #region Levels

        #endregion
        /// <summary>
        /// Add all resources in resource configurations
        /// </summary>
        private void AddAllLevels()
        {
            foreach (LevelConfig config in levelConfigs)
            {
                // Instantiate the resource's object
                GameObject obj = Instantiate(levelHolderPrefab.gameObject, levelParent, false);
                LevelControl resource = obj.GetComponent<LevelControl>();
            
                // Set resource's configuration
                resource.SetConfig(config);
                obj.SetActive(true);
            }
        }
    }

    [Serializable]
    public struct LevelConfig
    {
        public string name;
        public string sceneName;
    }
}