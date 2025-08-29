using System;
using Game.Ui.GameHudWindow;
using Game.Ui.SettingsWindow;
using Reflex.Core;
using UiCore;
using UnityEngine;

namespace Game.Installers
{
    public class UiInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private SettingsView _settingsView;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            var canvasTransform = _canvas.transform;
            
            var gameHudView = Instantiate(_gameHudView, canvasTransform);
            containerBuilder.AddSingleton(gameHudView, typeof(GameHudView));
            containerBuilder.AddSingleton(typeof(GameHudController));
            containerBuilder.AddSingleton(typeof(GameHudWindow), typeof(AWindow));
            
            var settingsView = Instantiate(_settingsView, canvasTransform);
            containerBuilder.AddSingleton(settingsView, typeof(SettingsView));
            containerBuilder.AddSingleton(typeof(SettingsController));
            containerBuilder.AddSingleton(typeof(SettingsWindow), typeof(AWindow));
            //SetupWindow<SettingsWindow>(_settingsView, containerBuilder, canvasTransform, typeof(SettingsController));
        }

        //TODO: complete something like this for more clean code for setup windows
        private void SetupWindow<TWindow>(AWindowView view, ContainerBuilder containerBuilder, Transform canvasTransform, Type controllerType) 
            where TWindow : AWindow
        {
            var settingsView = Instantiate(view, canvasTransform);
            containerBuilder.AddSingleton(settingsView, typeof(AWindowView));
            containerBuilder.AddSingleton(controllerType);
            containerBuilder.AddSingleton(typeof(TWindow), typeof(AWindow));
        }
    }
}