using System;
using Game.Services.GameSceneObjectsProvider;
using Game.Services.InputService;
using Game.Services.UiManager;
using Game.Views;
using R3;
using UiCore;
using UnityEngine;

namespace Game.Ui.GameHudWindow
{
    public class GameHudController : AWindowController<GameHudView>, IDisposable
    {
        private readonly PlayerView _playerView;
        private readonly Camera _camera;
        private readonly IInputService _inputService;
        
        private IDisposable _disposable;
        
        public GameHudController(
            GameHudView view,
            IGameSceneObjectsProvider gameSceneObjectsProvider,
            IInputService inputService,
            IUiManager uiManager
        ) : base(view)
        {
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
            _camera = gameSceneObjectsProvider.GameSceneObjects.Camera;
            _inputService = inputService;
            
            _disposable = _inputService.MousePosition.Subscribe(OnLookChange);
        }
        
        private void OnLookChange(Vector2 lookPosition)
        {
            var position = _camera.ScreenToWorldPoint(lookPosition);
            ///Debug.Log(position);
            Canvas canvas = View.GetComponentInParent<Canvas>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), lookPosition,
                _camera, out var pos);
            
            View.SetCrossfirePosition(pos);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}