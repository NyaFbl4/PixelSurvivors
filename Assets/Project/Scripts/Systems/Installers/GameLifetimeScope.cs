using MessagePipe;
using Project.Scripts.GameManager;
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
        }

        private void RegisterSystems(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterEntryPoint<GameManagerService>().As<IGameManagerService>();
        }

        private void RegisterHelpers(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameManagerHelper);
        }
    }
}