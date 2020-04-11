﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector2 localScale;

    public float speed;
    
    public bool dirY, MoveLeft;



    // Update is called once per frame
    void Update()
    {
        if (dirY)
        {
            if (MoveLeft)
            {
                transform.Translate(0, 2 * Time.deltaTime * speed, 0);
            }
            else
            {
                transform.Translate(0, -2 * Time.deltaTime * speed, 0);
            }
        }
        else
        {
            if (MoveLeft)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-localScale.x, localScale.y);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(localScale.x, localScale.y);
            }
        }

        CheckForDestroy();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.Die();
        }
    }
    public void CheckForDestroy()
    {
        if (dirY)
        {
            if (transform.childCount <= 7)
                Destroy(gameObject);
        }
        else
        {
            if (transform.childCount <= 5)
                Destroy(gameObject);
        }
    }






}
