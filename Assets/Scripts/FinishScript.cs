using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.presistentData.Coins += 50;
            if(Player.Instance.presistentData.Coins >= 100)
            {
                Player.Instance.presistentData.Lives++;
                Player.Instance.presistentData.Coins -= 100;
            }
            SceneManager.LoadScene("World");
        }
    }
}
