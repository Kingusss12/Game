using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : GameItem
{
    protected override void HandleUse(Player player)
    {
        base.HandleUse(player);
        player.presistentData.Coins++;
    }
}
