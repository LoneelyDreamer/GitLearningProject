using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutCoin : Coin
{
    public override void UseCoin()
    {
        Player player = GetComponentInParent<Player>();

        if (player != null)
            player.Shut();

        GameObject.Destroy(gameObject);
    }    
}
