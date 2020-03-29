using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj)
    {
      //  print("Coin collised");
        Player.Instance.coins += 1;
        Destroy(gameObject);

    }

}
