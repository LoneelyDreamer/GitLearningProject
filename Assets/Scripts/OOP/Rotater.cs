using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _roatateSpeed;
    private bool _isRotating;

    private float _time;
    private Vector3 _position;

    public void StopRotate()
    {
        _isRotating = false;
    }

    private void Update()
    {
        if(_isRotating == false)
            return;

        _time += Time.deltaTime;
        transform.Rotate(Vector3.up, _time * _roatateSpeed);
    }
}
