using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Systems.SpawnSystems
{
    public sealed class SpawnManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;

        [Header("Spawn Points")]
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private List<Transform> _enemySpawnPoints;

        private Transform _playerTransform;

        public GameObject SpawnPlayer()
        {
            if (_playerPrefab == null || _playerSpawnPoint == null) return null;

            var player = Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);
            _playerTransform = player.transform;
            return player;
        }

        public GameObject SpawnEnemy(float distanceN)
        {
            Debug.Log("spawn enemy");
            if (_enemyPrefab == null || _playerTransform == null) return null;
            Debug.Log("spawn enemy2");
            var dir = Random.insideUnitCircle.normalized;
            if (dir == Vector2.zero) dir = Vector2.right; // редкий случай
            Debug.Log("spawn enemy3");
            var spawnPos = (Vector2)_playerTransform.position + dir * distanceN;
            return Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        }

        // public void SpawnEnemies(int count)
        // {
        //     for (int i = 0; i < count; i++)
        //         SpawnEnemy();
        // }
    }
}
