using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public enum IdleStrategies
    {
        DoNothing,
        RandomDirection,
        RightOrger
    }

    public enum ReactingOnPlayerStrategies
    {
        Deth,
        Chasing,
        Run
    }


    public class StrategtPatern : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private List<Transform> _targets;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private IdleStrategies _idleStrategies;
        [SerializeField] private ReactingOnPlayerStrategies _reactingOnPlayerStrategies;

        private List<Enemy> _enemyPrefabs = new List<Enemy>();

        private float _step = 1f;
        private float _time = 0f;
        private ITargeSelector _selector;
        private IReactingOnPlayer _react;

        private void Start()
        {
            SpawnAll();
            InitAllEnemys();
        }

        public void InitAllEnemys()
        {
            switch (_idleStrategies)
            {
                case IdleStrategies.DoNothing:
                    _selector = new DoNothingSelector();
                    break;
                case IdleStrategies.RandomDirection:
                    _selector = new RandomDirectionSelector();
                    break;
                case IdleStrategies.RightOrger:
                    _selector = new RightOrgerTargetSelector();
                    break;
            }

            switch (_reactingOnPlayerStrategies)
            {
                case ReactingOnPlayerStrategies.Deth:
                    _react = new Deth();
                    break;
                case ReactingOnPlayerStrategies.Chasing:
                    _react = new IChasingPlayer();
                    break;
                case ReactingOnPlayerStrategies.Run:
                    _react = new IRunFromPlayer();
                    break;
            }

            foreach (var enemy in _enemyPrefabs)
            {
                enemy.Initialize(_selector, _react, _targets);
            }
        }

        public void SpawnAll()
        {
            foreach(var point in _spawnPoints)
            {
                SpawnEnemy(point.position);
            }
        }


        public Enemy SpawnEnemy(Vector3 position)
        {
            Enemy enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            _enemyPrefabs.Add(enemy);

            return enemy;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (_time > _step)
            {
                InitAllEnemys();
                _time = 0f;
            }
        }
    }
}