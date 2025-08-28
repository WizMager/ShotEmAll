using Game.Services.GameSceneObjectsProvider;
using Game.Services.GameSceneObjectsProvider.Impl;
using Game.Services.InputService;
using Game.Services.InputService.Impl;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameSceneObjects _gameSceneObjects;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(InputService), typeof(IInputService));
            containerBuilder.AddSingleton(new GameSceneObjectsProvider(_gameSceneObjects),
                typeof(IGameSceneObjectsProvider));
        }
    }
}