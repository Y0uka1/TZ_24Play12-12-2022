using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "CubeSpawnSettings", menuName = "ScriptableObjects/Settings/CubeSpawnSettings")]
    public class CubeSpawnSettings:ScriptableObject
    {
        [SerializeField] private int minimalNegativeCubeSpawnFrequency;
        [SerializeField] private int maximalNegativeCubeSpawnFrequency;
        [SerializeField] private int maximalPositiveCubeCollectionSize;

        public int MinimalNegativeCubeSpawnFrequency => minimalNegativeCubeSpawnFrequency;

        public int MaximalNegativeCubeSpawnFrequency => maximalNegativeCubeSpawnFrequency;
        
        public int MaximalPositiveCubeCollectionSize => maximalPositiveCubeCollectionSize;
    }
}