using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Services.InputService.Impl
{
    public class InputService : IInputService, IDisposable
    {
        private readonly InputSystem_Actions _actions = new();
        
        public bool IsMove { get; private set; }
        public Vector2 MoveDirection { get; private set; }

        public InputService()
        {
            _actions.Enable();
            
            _actions.Player.Movement.performed += OnMovePerformed;
            _actions.Player.Movement.canceled += OnMoveCanceled;
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            if (!IsMove)
            {
                IsMove = true;
            }
            
            MoveDirection = context.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            IsMove = false;
        }

        public void Dispose()
        {
            _actions.Player.Movement.performed += OnMovePerformed;
            _actions.Player.Movement.canceled -= OnMoveCanceled;
            
            _actions.Disable();
            _actions.Dispose();
        }
    }
}