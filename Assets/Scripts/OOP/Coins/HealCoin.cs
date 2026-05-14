using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealCoin : Coin
{
    public override void UseCoin()
    {
        Player player = GetComponentInParent<Player>();

        if (player != null)
            player.Heal();

        GameObject.Destroy(gameObject);
    }
}
