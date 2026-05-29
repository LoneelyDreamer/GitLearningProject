using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NavMesh
{
    internal class CompositController : Controller
    {
        private Controller[] _controllers;

        public CompositController(params Controller[] controllers)
        {
            _controllers = controllers;
        }

        public override void Enable()
        {
            base.Enable();
            foreach (var controller in _controllers)            
                controller.Enable();
            
        }

        public override void Disable()
        {
            base.Disable();
            foreach (var controller in _controllers)
                controller.Disable();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            foreach (var controller in _controllers)
                controller.Update(deltaTime);
        }
    }
}
