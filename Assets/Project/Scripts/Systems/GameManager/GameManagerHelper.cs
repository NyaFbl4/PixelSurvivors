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
            _gameManagerService = gameManagerService;
        }
        
        [Button]
        public void StartGame()
        {
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