using Game.Services.InputService;
using GameLoop.Interfaces;
using Generator;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 123)]
    public class TestController : IStartable, IUpdatable
    {
        public TestController(IInputService inputService)
        {
            
        }
        
        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }
}