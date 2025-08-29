using UiCore;

namespace Game.Services.UiManager
{
    public interface IUiManager
    {
        public void OpenWindow(EWindowName windowName);
        public void CloseWindows();
    }
}