using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour
{

    public GameObject helpPanel;


    public void Open()
    {
        helpPanel.gameObject.SetActive(true);    
    }

    public void Close()
    {
        helpPanel.gameObject.SetActive(false);
    }
}
