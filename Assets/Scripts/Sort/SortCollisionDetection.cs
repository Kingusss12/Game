using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCollisionDetection : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnCollision;
    public UnityEngine.Events.UnityEvent OnCollisionLeave;
    public bool wasTouched = false;
    Vector2 originalPos;

    private void Start()
    {
        originalPos = new Vector2(transform.position.x, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (wasTouched)
            return;
        OnCollision.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCollisionLeave.Invoke();
    }

    public void Reset()
    {
        GetComponent<Renderer>().material.color = Color.white;
        transform.position = originalPos;
    }


}
