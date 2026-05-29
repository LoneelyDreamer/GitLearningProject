using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NavMesh
{
    public class AlongMovableRotatobleController : Controller
    {
        private IDiractionalMoveble _diractionalMoveble;
        private IDiractionalRotator _diractionalRotator;

        public AlongMovableRotatobleController(IDiractionalMoveble diractionalMoveble, IDiractionalRotator diractionalRotator)
        {
            _diractionalMoveble = diractionalMoveble;
            _diractionalRotator = diractionalRotator;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _diractionalRotator.SetRotationDiraction(_diractionalMoveble.CurrrentVelocity);
        }
    }
}
