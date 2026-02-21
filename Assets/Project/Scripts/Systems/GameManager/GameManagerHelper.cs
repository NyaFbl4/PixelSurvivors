using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Project.Scripts.GameManager
{
    public class GameManagerHelper : MonoBehaviour
    {
        private IGameManagerService _gameManagerService;

        [Inject]
        public void Construct(IGameManagerService gameManagerService)
        {
            Debug.Log("GameManagerHelper install");
            _gameManagerService = gameManagerService;
        }
        
        [Button]
        public void StartGame()
        {
            if (_gameManagerService == null)
            {
                Debug.LogError("GameManagerService is null. Ensure GameManagerHelper is injected via GameLifetimeScope and run in Play Mode.");
                return;
            }
            _gameManagerService.StartGame();
        }
        [Button]
        public void FinishGame()
        {
            _gameManagerService.FinishGame();
        }
        
        [Button]
        public void PauseGame()
        {
            _gameManagerService.PauseGame();
        }

        [Button]
        public void ResumeGame()
        {
            _gameManagerService.ResumeGame();
        }
    }
}