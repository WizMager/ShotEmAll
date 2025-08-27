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
    [Install(EExecutionPriority.Normal, 255)]
    public class PlayerLookController : IStartable, IDisposable
    {
        private readonly Camera _camera;
        private readonly IInputService _inputService;
        private readonly PlayerView _playerView;
        
        private IDisposable _disposable;
        
        public PlayerLookController(
            IGameSceneObjectsProvider gameSceneObjectsProvider,
            IInputService inputService
        )
        {
            _camera = gameSceneObjectsProvider.GameSceneObjects.Camera;
            _inputService = inputService;
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
        }
        
        public void Start()
        {
            _disposable = _inputService.MousePosition.Subscribe(OnLookChange);
            
            var cameraPosition  = _playerView.transform.position;
            cameraPosition.y = 5;
            
            _camera.transform.position = cameraPosition;
            _camera.transform.parent = _playerView.transform;
        }

        private void OnLookChange(Vector2 lookPosition)
        {
            Debug.Log(lookPosition);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}