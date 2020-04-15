using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{

    public Text congrat;
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
            StartCoroutine(Congratulation());
            
        }
    }

    public IEnumerator Congratulation()
    {
        AudioManager.playYay();
        congrat.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        congrat.gameObject.SetActive(false);
        SceneManager.LoadScene("World");
    }
}
