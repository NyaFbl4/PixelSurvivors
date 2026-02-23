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
    public class ShowPopUpUseCase : IInitializable, IDisposable, IMessageHandler<ShowPopupDto>
    {
        [Inject] private readonly ISubscriber<ShowPopupDto> _showPopUpSubscriber;
        [Inject] private readonly IUIController _uiController;
        private CompositeDisposable  _disposable = new();
        
        public void Initialize()
        {
            _showPopUpSubscriber.Subscribe(this).AddTo(_disposable);
        }
        
        public void Handle(ShowPopupDto message)
        {
            Debug.Log("ShowPopUpUseCase Handle" + message.TargetPopUpType);
            _uiController.ShowPopup(message.TargetPopUpType);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}