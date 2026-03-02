using Project.Scripts.Systems.SpawnSystems;
using UnityEngine;
using VContainer.Unity;

namespace Project.Scripts.Systems.GameBootstrap
{
    public class GameBootstrapper : IInitializable
    {
        private SpawnManager _spawnManager;

        public GameBootstrapper(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;
        }

        public void Initialize()
        {
            Debug.Log("Bootstrap init");

            _spawnManager.SpawnPlayer();
        }
    }
}
