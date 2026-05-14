using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
    private float _time;
    private float _lifeTime = 10f;

    private void Update()
    { 
        if( _lifeTime > _time )
        {
            _time += Time.deltaTime;         
        }
        else
        {
            GameObject.Destroy(gameObject);
        }       
    }
}
