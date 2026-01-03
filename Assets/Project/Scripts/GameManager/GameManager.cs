using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
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
    }
}