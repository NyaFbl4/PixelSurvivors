using MessagePipe;
using Project.Scripts.GameManager;
using Project.Scripts.Systems.UI;
using Project.Scripts.UI.MainScreen;
using Project.Scripts.UI.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Systems.Installers
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameManagerHelper _gameManagerHelper;
        [SerializeField] private MainMenuView _mainMenuView;
        // [SerializeField] private 
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterSystems(builder);
            RegisterHelpers(builder);
            RegisterUseCases(builder);
            RegisterViews(builder);
            RegisterPresenters(builder);
        }

        private void RegisterSystems(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterEntryPoint<UIController>().As<IUIController>();
            builder.RegisterEntryPoint<GameManagerService>().As<IGameManagerService>();
            // builder.RegisterMessagePipe();
            // builder.RegisterEntryPoint<GameManagerService>().As<IGameManagerService>();
            // builder.Register<UIController>(Lifetime.Singleton).As<IUIController>();
            // builder.RegisterEntryPoint<UIMessageHandler>();
        }

        private void RegisterUseCases(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<HidePopUpUseCase>(Lifetime.Singleton);
            builder.RegisterEntryPoint<ShowPopUpUseCase>(Lifetime.Singleton);
        }

        private void RegisterHelpers(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManagerHelper>();
        }

        private void RegisterViews(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_mainMenuView, Lifetime.Scoped).As<IMainMenuView>();
        }
        
        private void RegisterPresenters(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuPresenter>(Lifetime.Scoped);
        }
    }
}
