using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCollisionDetection : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnCollision;
    private bool wasTouched = false;
    Vector2 originalPos;

    private void Start()
    {
        originalPos = new Vector2(transform.position.x, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (wasTouched)
        //    return;
        wasTouched = true;
        OnCollision.Invoke();
    }

    public void Reset()
    {
        wasTouched = false;
        GetComponent<Renderer>().material.color = Color.white;
        transform.position = originalPos;
    }


}
