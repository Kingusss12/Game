using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            Player.Instance.presistentData.Coins++;
            Destroy(gameObject);
        }
    }

    //protected override void HandleUse(Player player)
    //{
    //    base.HandleUse(player);
    //    player.presistentData.Coins++;
    //}
}
