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
            Player.Instance.coins += 50;
            if(Player.Instance.coins >= 100)
            {
                Player.Instance.lives++;
                Player.Instance.coins -= 100;
            }
            SceneManager.LoadScene("World");
        }
    }
}
