using System.Collections.Generic;
using Ui;

namespace Game.Services.UiManager.Impl
{
    public class UiManager : IUiManager
    {
        public UiManager(IEnumerable<Window> windows)
        {
            foreach (var window in windows)
            {
                window.AddControllers();
            }
        }
    }
}