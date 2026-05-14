using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _forse;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _coinInHandPosition;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _hp;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private ParticleSystem _particle;

    public Transform CoinInHandPosition => _coinInHandPosition;
    public bool ISCoinInHand => _isCoinInHands;

    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private KeyCode UseCoinKey = KeyCode.F;
    private bool _isCoinKeyDown;
    private bool _isCoinInHands;
    private float _deadZone = 0.05f;
    private float _xInput;
    private float _yInput;
    private Vector3 _input;
    private Coin _coin;

    private void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _yInput = Input.GetAxis(VerticalAxis);
        _input = new Vector3(_xInput, 0, _yInput);   
        
        _isCoinKeyDown = Input.GetKeyDown(UseCoinKey);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(_xInput) >_deadZone)
        {
            _rigidbody.AddForce(Vector3.right * _forse * _xInput);
            ProcessRotateTo(_input);
        }

        if (Mathf.Abs(_yInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.forward * _forse * _yInput);
            ProcessRotateTo(_input);
        }      

        if (_isCoinKeyDown)
        {
            if (_coin != null)
            {
                UseCoin();
            }
            else
                Debug.Log("No coin in hands");
            
        }
    }

    private void UseCoin()
    {
        _coin.UseCoin();
        _coin = null;
        _particle.Play();
        _isCoinInHands = false;
    }

    public void GetCoin(Coin coin)
    {
        _coin = coin;
        _isCoinInHands = true;
    }
    
    public void Heal()
    {
        _hp = _maxHp;
        Debug.Log("Heal");
    }

    public void UpgradeSpeed(int value)
    {
        _forse += value;
        Debug.Log("UpgradeSpeed");
    }

    public void Shut()
    {
        Rigidbody bullet = Instantiate(_bulletPrefab, _coinInHandPosition.position ,Quaternion.identity);
        bullet.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        Debug.Log("Shut");        
    }
}
