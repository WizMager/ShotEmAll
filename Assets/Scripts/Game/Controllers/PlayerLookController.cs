using System;
using Game.Services.GameSceneObjectsProvider;
using Game.Services.InputService;
using Game.Views;
using GameLoop.Interfaces;
using Generator;
using R3;
using UnityEngine;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 240)]
    public class PlayerLookController : IStartable, IDisposable
    {
        private readonly Camera _camera;
        private readonly PlayerView _playerView;
        private readonly IDisposable _disposable;
        
        private Plane _groundPlane;
        
        public PlayerLookController(
            IGameSceneObjectsProvider gameSceneObjectsProvider, 
            IInputService inputService
        )
        {
            _camera = gameSceneObjectsProvider.GameSceneObjects.Camera;
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
            
            _disposable = inputService.MousePosition.Subscribe(OnCrossfirePositionChange);
        }
        
        public void Start()
        {
            _groundPlane = new Plane(Vector3.up, _playerView.transform.position);
        }
        
        private void OnCrossfirePositionChange(Vector2 mousePosition)
        {
            var ray = _camera.ScreenPointToRay(mousePosition);

            if (_groundPlane.Raycast(ray, out var enter))
            {
                var hitPoint = ray.GetPoint(enter);
                var direction = hitPoint - _playerView.transform.position;
                direction.y = 0;

                if (direction.magnitude > 0.1f)
                {
                    _playerView.transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}