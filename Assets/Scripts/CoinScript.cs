using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("CoinRotation",0, Random.Range(0.0f,1f));
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.presistentData.Coins++;
            Destroy(gameObject);
            AudioManager.playCoinCollected();
        }
    }

    //protected override void HandleUse(Player player)
    //{
    //    base.HandleUse(player);
    //    player.presistentData.Coins++;
    //    AudioManager.playCoinCollected();

    //}
}
