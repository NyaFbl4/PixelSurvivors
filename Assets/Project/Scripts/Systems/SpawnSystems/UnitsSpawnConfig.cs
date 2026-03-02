using UnityEngine;

namespace Project.Scripts.Systems.SpawnSystems
{
    [CreateAssetMenu(fileName = "UnitsSpawnConfig", menuName = "Configs/Spawn configs")]
    public class UnitsSpawnConfig : ScriptableObject
    {
        [SerializeField] 
        private  GameObject _player;
    }
}