using MessagePipe;
using Project.Scripts.GameManager;
using Project.Scripts.Systems.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Systems.Installers
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameManagerHelper _gameManagerHelper;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterSystems(builder);
            RegisterHelpers(builder);
            RegisterViews(builder);
            RegisterPresenters(builder);
        }

        private void RegisterSystems(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterEntryPoint<GameManagerService>().As<IGameManagerService>();
            builder.Register<UIController>(Lifetime.Singleton).As<IUIController>();
            builder.RegisterEntryPoint<UIMessageHandler>();
        }

        private void RegisterHelpers(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManagerHelper>();
        }

        private void RegisterViews(IContainerBuilder builder)
        {

        }
        
        private void RegisterPresenters(IContainerBuilder builder)
        {

        }
    }
}
