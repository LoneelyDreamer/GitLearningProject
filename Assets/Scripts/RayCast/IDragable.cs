using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public interface IDragable
    {
        public void Drag(Vector3 target);        
    }
}
