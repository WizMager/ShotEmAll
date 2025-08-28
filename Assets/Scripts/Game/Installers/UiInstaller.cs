using Game.Ui.GameHudWindow;
using Reflex.Core;
using Ui;
using UnityEngine;

namespace Game.Installers
{
    public class UiInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameHudView _gameHudView;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            var canvasTransform = _canvas.transform;
            
            var gameHudView = Instantiate(_gameHudView, canvasTransform);
            containerBuilder.AddSingleton(gameHudView, typeof(GameHudView));
            containerBuilder.AddSingleton(typeof(GameHudController));
            containerBuilder.AddSingleton(typeof(GameHudWindow), typeof(Window));
        }
    }
}