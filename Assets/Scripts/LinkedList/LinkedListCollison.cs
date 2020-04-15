using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkedListCollison : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnCollision;
    private bool wasTouched = false;
    public static bool keyE = false;
    public static bool keyR = false;


    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (wasTouched)
            return;
            wasTouched = true;
            OnCollision.Invoke();

    }

    public void Reset()
    {
        keyE = false;
        keyR = false;
        wasTouched = false;
        GetComponent<Renderer>().material.color = Color.white;
        //if (OrderManager.noChild)
        //{
           gameObject.SetActive(true);
        //    OrderManager.noChild = false;
        //}
        //else transform.GetChild(0).gameObject.SetActive(false);
        
    }
}
