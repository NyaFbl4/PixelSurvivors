using System;
using Project.Scripts.GameManager;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class MoveComponent: MonoBehaviour, IGameStartListener, IGameFinishListener, IGameFixedUpdateListener
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _moveSpeed;
        
        private float _directionX;
        private float _directionY;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStartGame()
        {
            _inputManager.OnMoveX += OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }
        
        public void OnFinishGame()
        {
            _inputManager.OnMoveX -= OnMoveX;
            _inputManager.OnMoveY -= OnMoveY;
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _rigidbody2D.linearVelocity = new Vector2(_directionX, _directionY ) * _moveSpeed;
        }
        
        private void OnMoveX(float directionX)
        {
            _directionX = directionX;
        }
        
        private void OnMoveY(float directionY)
        {
            _directionY = directionY;
        }
    }
}