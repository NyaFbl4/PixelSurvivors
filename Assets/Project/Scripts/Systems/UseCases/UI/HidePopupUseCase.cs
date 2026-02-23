using System;
using MessagePipe;
using Project.Scripts.Systems.UI;
using Project.Scripts.Systems.UI.Dtos;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.UI.UseCases
{
    public class HidePopUpUseCase : IInitializable, IDisposable,
        IMessageHandler<HidePopupDto>
    {
        [Inject] private readonly ISubscriber<HidePopupDto> _hidePopUpSubscriber;
        [Inject] private readonly IUIController _uiController;
        
        private CompositeDisposable _disposable = new ();
        
        public void Initialize()
        {
            _hidePopUpSubscriber.Subscribe(this).AddTo(_disposable);
        }
        
        public void Handle(HidePopupDto message)
        {
            Debug.Log("HidePopUpUseCase Handle" + message.TargetPopUpType);
            _uiController.HidePopup(message.TargetPopUpType);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}