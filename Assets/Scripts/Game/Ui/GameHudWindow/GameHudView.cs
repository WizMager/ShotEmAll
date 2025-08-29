using UiCore;
using UnityEngine;

namespace Game.Ui.GameHudWindow
{
    public class GameHudView : AWindowView
    {
        [SerializeField] private RectTransform _crossfireTransform;

        public void SetCrossfirePosition(Vector2 position)
        {
            _crossfireTransform.anchoredPosition = position;
        }
    }
}