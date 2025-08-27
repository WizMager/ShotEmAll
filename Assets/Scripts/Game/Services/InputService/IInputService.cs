using R3;
using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        ReactiveProperty<Vector2> MousePosition { get; }
        bool IsMove { get; }
        Vector2 MoveDirection { get; }
    }
}