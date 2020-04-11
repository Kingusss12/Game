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
    // Start is called before the first frame update
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        IsOpen = true;
        GateDoor.SetActive(true);
        Destroy(gameObject.GetComponent<Collider2D>());
    }
}
