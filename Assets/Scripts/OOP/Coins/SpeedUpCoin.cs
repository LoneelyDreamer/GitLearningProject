

using UnityEngine;

public class SpeedUpCoin : Coin
{
    private int _speedBoost = 2;
    public override void UseCoin()
    {
        Player player = GetComponentInParent<Player>();

        if (player != null)
            player.UpgradeSpeed(_speedBoost);

        GameObject.Destroy(gameObject);
    }
}

