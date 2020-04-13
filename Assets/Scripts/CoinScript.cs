using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : GameItem
{
    

    //private void Start()
    //{
    //    Animator anim = GetComponent<Animator>();
    //    anim.Play("CoinRotation",0, Random.Range(0.0f,1f));
    //}

    //void OnTriggerEnter2D(Collider2D obj)
    //{
    //    if(obj.gameObject.tag == "Player")
    //    {
    //        Player.Instance.coins++;
    //        Destroy(gameObject);
    //        AudioManager.playCoinCollected();
    //    }
    //}

    protected override void HandleUse(Player player)
    {
        base.HandleUse(player);
        player.presistentData.Coins++;
    }
}
