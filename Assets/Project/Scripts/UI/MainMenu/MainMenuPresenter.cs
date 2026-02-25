using System;
using MessagePipe;
using Project.Scripts.Systems.UI;
using Project.Scripts.Systems.UI.Dtos;
using R3;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.UI.MainScreen
{
    public class MainMenuPresenter : LayoutPresenterBase<IMainMenuView>, IMainMenuPresenter,
        IInitializable, IDisposable
    {
        [Inject] private readonly IPublisher<ShowPopupDto> _showPopUpPublisher;
        [Inject] private readonly IPublisher<HidePopupDto> _hidePopUpPublisher;
        
        private readonly CompositeDisposable _disposable = new();

        public void Initialize()
        {
            base.Initialize();
        }

        public void Dispose()
        {
            // _layoutView.BattlePassButton.clicked -= OnBattlePassClicked;
            
            _disposable?.Dispose();
        }

        private void OnBattlePassClicked()
        {
            // _hidePopUpPublisher.Publish(new HidePopupDto
            // {
            //     TargetPopUpType = typeof(IMainMenuPresenter)
            // });
            
            // _showPopUpPublisher.Publish(new ShowPopupDto
            // {
            //     TargetPopUpType = typeof(IBattlePassPresenter)
            // });
        }
    }
}