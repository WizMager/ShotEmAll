using System;
using Game.Services.GameSceneObjectsProvider;
using Game.Views;
using GameLoop.Interfaces;
using Generator;
using UnityEngine;

namespace Game.Controllers
{
    [Install(EExecutionPriority.High, 100)]
    public class PlayerCameraInitializeController : IStartable
    {
        private readonly Camera _camera;
        private readonly PlayerView _playerView;
        
        private IDisposable _disposable;
        
        public PlayerCameraInitializeController(IGameSceneObjectsProvider gameSceneObjectsProvider)
        {
            _camera = gameSceneObjectsProvider.GameSceneObjects.Camera;
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
        }
        
        public void Start()
        {
            var cameraPosition  = _playerView.transform.position;
            cameraPosition.y = 5;
            
            _camera.transform.position = cameraPosition;
            _camera.transform.parent = _playerView.transform;
        }
    }
}