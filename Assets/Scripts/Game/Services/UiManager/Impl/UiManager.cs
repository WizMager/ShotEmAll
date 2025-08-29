using System.Collections.Generic;
using UiCore;

namespace Game.Services.UiManager.Impl
{
    public class UiManager : IUiManager
    {
        private readonly Dictionary<EWindowName, AWindow> _windows = new();
        private EWindowName _activeWindow = EWindowName.None;
        
        public UiManager(IEnumerable<AWindow> windows)
        {
            foreach (var window in windows)
            {
                window.AddControllers();
                window.Activation(false);
                _windows.TryAdd(window.WindowName, window);
            }
        }

        public void OpenWindow(EWindowName windowName)
        {
            if (_activeWindow != EWindowName.None)
            {
                _windows[_activeWindow].Activation(false);
            }
            
            _activeWindow = windowName;
            _windows[_activeWindow].Activation(true);
        }

        public void CloseWindows()
        {
            foreach (var window in _windows)
            {
                window.Value.Activation(false);
            }
        }
    }
}