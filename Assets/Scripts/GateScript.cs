using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{

    //private Animator anim;
    public GameObject GateDoor;

    public bool IsOpen
    {
        get;
        private set;
    }
 

    public void Open()
    {
        AudioManager.playGateOpen();
        IsOpen = true;
        GateDoor.SetActive(true);
        Destroy(gameObject.GetComponent<Collider2D>());
    }
}
