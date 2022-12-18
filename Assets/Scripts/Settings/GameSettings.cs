using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/Settings/GameSettings")]
    public class GameSettings:ScriptableObject
    {
        [SerializeField] private float basicSpeed;

        public float BasicSpeed => basicSpeed;
    }
}