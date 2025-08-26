using GameLoop.Interfaces;
using Generator;
using UnityEngine;

namespace Game.Contollers
{
    [Install(EExecutionPriority.Normal, 123)]
    public class TestController : IStartable, IUpdatable
    {
        public void Start()
        {
            Debug.Log("Test contrl");
        }

        public void Update()
        {
            Debug.Log("Test contrl UPD");
        }
    }
}