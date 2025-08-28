using Reflex.Core;
using Ui;

namespace Game.Ui.GameHudWindow
{
    public class GameHudWindow : Window
    {
        public GameHudWindow(Container containerBuilder) : base(containerBuilder)
        {
        }

        public override void AddControllers()
        {
            AddController<GameHudController>();
        }
    }
}