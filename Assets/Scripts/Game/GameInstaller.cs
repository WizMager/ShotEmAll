using Game.Services.InputService;
using Game.Services.InputService.Impl;
using Reflex.Core;
using UnityEngine;

namespace Game
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(InputService), typeof(IInputService));
        }
    }
}