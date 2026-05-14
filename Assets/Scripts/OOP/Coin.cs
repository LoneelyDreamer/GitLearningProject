using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coin : MonoBehaviour
{
    [SerializeField] protected Rotater _rotater;

    private void OnTriggerEnter(Collider other)
    {
        GetCoin(other);
    }

    private void GetCoin(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null && player.ISCoinInHand == false)
        {
            _rotater.StopRotate();
            transform.SetParent(other.transform);
            transform.position = player.CoinInHandPosition.position;
            player.GetCoin(this);
        }
    }

    public abstract void UseCoin();

    
   
}
