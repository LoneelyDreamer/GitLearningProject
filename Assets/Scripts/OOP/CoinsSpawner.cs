using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Coin> _coins;

    private float _time;
    private float _cooldown = 2f;

    private void Update()
    {
        _time += Time.deltaTime;

        if( _time >= _cooldown )
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];   
            Coin coin = Instantiate(_coins[Random.Range(0, _spawnPoints.Count)], spawnPoint.position, Quaternion.identity);
            _time = 0;  
        }
    }
}
