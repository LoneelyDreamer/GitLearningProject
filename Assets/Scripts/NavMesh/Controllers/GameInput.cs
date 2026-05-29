using UnityEngine;

namespace Assets.Scripts.NavMesh
{   
    public class GameInput : MonoBehaviour
    {
        [SerializeField] Charecter _charecter;
        [SerializeField] AgentCharacter _agentEnemy;

        private Controller _characterController;
        private Controller _agentEnemyController;


        private void Awake()
        {
            _characterController = new CompositController(
                new PlayerDiractionalMovebleController(_charecter),
                new PlayerDiractionalRotatorController(_charecter)
                );

            _characterController.Enable();

            _agentEnemyController = new AgenyCharacterAgroController(_agentEnemy, _charecter.transform, 30, 2, 1);

            _agentEnemyController.Enable();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);
            _agentEnemyController.Update(Time.deltaTime);
        }
    }

    

}
