using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script detects the collision of sprites with the player
Stores collised gameobjects to a list and increase the index of the array
*/
public class CollisionDetection : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnCollision;
    private bool wasTouched = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (wasTouched)
           return;
        wasTouched = true;
        OnCollision.Invoke();
    }

    public void Reset()
    {
        wasTouched = false;
        GetComponent<Renderer>().material.color = Color.white;
    }

}
