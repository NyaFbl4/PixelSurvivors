using System;
using Project.Scripts.GameManager;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class InputManager: MonoBehaviour, IGameUpdateListener
    {
        public event Action<float> OnMoveX;
        public event Action<float> OnMoveY;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnUpdate(float deltaTime)
        {
            float directionX = 0;
            float directionY = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                directionX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                directionX = 1;
            }
            else
            {
                directionX = 0;
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionY = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                directionY = -1;
            }
            else
            {
                directionY = 0;
            }

            OnMoveX?.Invoke(directionX);
            OnMoveY?.Invoke(directionY);
        }
    }
}