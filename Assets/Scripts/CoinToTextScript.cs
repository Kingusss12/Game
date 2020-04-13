using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinToTextScript : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Instance.presistentData.Coins >= 100)
        {
            Player.Instance.presistentData.Coins = 0;
            Player.Instance.presistentData.Coins += 1; 
        }
        text.text = Player.Instance.presistentData.Coins.ToString();
    }
}
