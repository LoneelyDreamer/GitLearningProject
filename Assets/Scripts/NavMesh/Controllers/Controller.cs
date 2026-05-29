using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public abstract class Controller
    {
        private bool _isEnabled;

        public virtual void Enable() => _isEnabled = true;

        public virtual void Disable() => _isEnabled = false;

        public void Update(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
      
    }
}
