using MessagePipe;
using Project.Scripts.Systems.UI.Dtos;
using Project.Scripts.UI.MainScreen;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Project.Scripts.GameManager
{
    public class GameManagerHelper : MonoBehaviour
    {
        private IPublisher<ShowPopupDto> _showPopupDto;
        private IPublisher<HidePopupDto> _hidePopupDto;
        private IGameManagerService _gameManagerService;
        private MainMenuPresenter _mainMenuPresenter;

        [Inject]
        public void Construct(
            IGameManagerService gameManagerService,
            IPublisher<ShowPopupDto> showPopupDto,
            IPublisher<HidePopupDto> hidePopupDto)
        {
            Debug.Log("GameManagerHelper install");
            _gameManagerService = gameManagerService;
            _showPopupDto = showPopupDto;
            _hidePopupDto = hidePopupDto;
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

        [Button]
        public void ShowView()
        {
            _showPopupDto.Publish(new ShowPopupDto
            {
               TargetPopUpType = typeof(IMainMenuPresenter)  
            });
        }

        [Button]
        public void HideView()
        {
            _hidePopupDto.Publish(new HidePopupDto
            {
               TargetPopUpType = typeof(IMainMenuPresenter)  
            });
        }
    }
}