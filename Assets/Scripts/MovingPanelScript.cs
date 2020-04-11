using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanelScript : MonoBehaviour
{
    public Vector2 localScale;

    public float speed;

    public bool MoveLeft, X;


    // Update is called once per frame
    void Update()
    {
        if (X)
        {
            if (MoveLeft)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
               // transform.localScale = new Vector2(-localScale.x, localScale.y);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
               // transform.localScale = new Vector2(localScale.x, localScale.y);
            }
        }
        else
        {
            if (MoveLeft)
            {
                transform.Translate(0, 2 * Time.deltaTime * speed, 0);
                //transform.localScale = new Vector2(localScale.x, localScale.y);
            }
            else
            {
                transform.Translate(0, -2 * Time.deltaTime * speed, 0);
                //transform.localScale = new Vector2(localScale.x, localScale.y);
            }
      
       }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turn"))
        {
            if (MoveLeft)
            {
                MoveLeft = false;
            }
            else MoveLeft = true;
        }

    }
}
