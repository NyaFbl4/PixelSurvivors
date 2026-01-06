using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.GameManager
{
    public class GameManagerService : MonoBehaviour
    {
        [SerializeField, Unity.Collections.ReadOnly]
        private EGameState _gameState;

        private readonly List<IGameListener>  _gameListeners = new();
        private readonly List<IGameUpdateListener>  _gameUpdateListeners = new();
        private readonly List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();
        
        public event Action OnStartGame;

        private void Awake()
        {
            _gameState = EGameState.Off;

            IGameListener.onRegister += AddListener;
            IGameListener.onUnregister += RemoveListener;
        }

        private void OnDestroy()
        {
            _gameState = EGameState.Finish;
            
            IGameListener.onRegister -= RemoveListener;
            IGameListener.onUnregister -= AddListener;
        }

        private void Update()
        {
            if (_gameState != EGameState.Play)
                return;
            
            var deltaTime = Time.deltaTime;

            foreach (var listener in _gameUpdateListeners)
            {
                listener.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if(_gameState != EGameState.Play)
                return;
            
            var deltaTime = Time.deltaTime;
            
            foreach (var listener in _gameFixedUpdateListeners)
            {
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void AddListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
                _gameUpdateListeners.Add(gameUpdateListener);

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
                _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
        }
        
        private void RemoveListener(IGameListener gameListener)
        {
            _gameListeners.Remove(gameListener);
            
            if (gameListener is IGameUpdateListener gameUpdateListener)
                _gameUpdateListeners.Remove(gameUpdateListener);

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
                _gameFixedUpdateListeners.Remove(gameFixedUpdateListener);
        }

        [Button]
        private void StartGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameStartListener)
                {
                    gameStartListener.OnStartGame();
                    Debug.Log("IGameStartListener");
                }
            }

            _gameState = EGameState.Play;
            Time.timeScale = 1;
            Debug.Log("START GAME");
        }
        [Button]
        public void FinishGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = EGameState.Finish;
            Debug.Log("FINISH");
        }
        
        [Button]
        public void PauseGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnPauseGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = EGameState.Pause;
            Debug.Log("PAUSE");
        }
        
        [Button]
        public void ResumeGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnResumeGame();
                }
            }
            
            Time.timeScale = 1;
            _gameState = EGameState.Play;
            Debug.Log("RESUME");
        }
    }
    
    /*public class GameManagerService : IGameManagerService,
        IStartable, ITickable, IFixedTickable, IDisposable //MonoBehaviour
    {
        //[SerializeField, Unity.Collections.ReadOnly]
        private EGameState _gameState;

        private readonly List<IGameListener>  _gameListeners = new();
        private readonly List<IGameUpdateListener>  _gameUpdateListeners = new();
        private readonly List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();
        
        public event Action OnStartGame;

        [Inject]
        private GameManagerService()
        {
            /*_gameState = EGameState.Off;#1#

            IGameListener.onRegister += AddListener;
            IGameListener.onUnregister += RemoveListener;
        }

        public void Start()
        {
            _gameState = EGameState.Play;
        }

        public void Dispose()
        {
            _gameState = EGameState.Finish;
            
            IGameListener.onRegister -= RemoveListener;
            IGameListener.onUnregister -= AddListener;
            
            _gameListeners.Clear();
            _gameUpdateListeners.Clear();
            _gameFixedUpdateListeners.Clear();
        }

        public void Tick()
        {
            if (_gameState != EGameState.Play)
                return;
            
            var deltaTime = Time.deltaTime;

            foreach (var listener in _gameUpdateListeners)
            {
                listener.OnUpdate(deltaTime);
            }
        }

        public void FixedTick()
        { 
            if(_gameState != EGameState.Play)
                return;
            
            var deltaTime = Time.deltaTime;
            
            foreach (var listener in _gameFixedUpdateListeners)
            {
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void AddListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
                _gameUpdateListeners.Add(gameUpdateListener);

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
                _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
        }
        
        private void RemoveListener(IGameListener gameListener)
        {
            _gameListeners.Remove(gameListener);
            
            if (gameListener is IGameUpdateListener gameUpdateListener)
                _gameUpdateListeners.Remove(gameUpdateListener);

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
                _gameFixedUpdateListeners.Remove(gameFixedUpdateListener);
        }

        //[Button]
        public void StartGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameStartListener)
                {
                    gameStartListener.OnStartGame();
                    Debug.Log("IGameStartListener");
                }
            }

            _gameState = EGameState.Play;
            Time.timeScale = 1;
            Debug.Log("START GAME");
        }
        /*[Button]#1#
        public void FinishGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = EGameState.Finish;
            Debug.Log("FINISH");
        }
        
        /*[Button]#1#
        public void PauseGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnPauseGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = EGameState.Pause;
            Debug.Log("PAUSE");
        }
        
        /*[Button]#1#
        public void ResumeGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnResumeGame();
                }
            }
            
            Time.timeScale = 1;
            _gameState = EGameState.Play;
            Debug.Log("RESUME");
        }
    }*/
}