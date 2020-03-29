using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject HelpPanel, unlockText, HelpText;
    bool IsUnlocked = false;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!IsUnlocked)
            {
                HelpPanel.gameObject.SetActive(true);
                unlockText.gameObject.SetActive(true);
            }
            else
            {
                HelpPanel.gameObject.SetActive(true);
            }
        }
    }

    public void ExitHelp()
    {
        HelpPanel.gameObject.SetActive(false);
    }

    public void unlockHelp()
    {
        if(Player.Instance.presistentData.Coins >= 50)
        {
            Player.Instance.presistentData.Coins -= 50;
            unlockText.gameObject.SetActive(false);
            HelpText.gameObject.SetActive(true);
            IsUnlocked = true;
        }
        else
        {
            ExitHelp();
        }
    }

    public void Open()
    {
        if (!IsUnlocked)
        {
            IsUnlocked = true;
            HelpPanel.gameObject.SetActive(true);
            unlockText.gameObject.SetActive(false);
            HelpText.gameObject.SetActive(true);
        }
    }

}
