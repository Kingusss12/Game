using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DiamondTreeTraversal")
        {
            Player.Instance.presistentData.TreeTraversal = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondBinarySearchTree")
        {
            Player.Instance.presistentData.BinarySearchTree = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondSort")
        {
            Player.Instance.presistentData.Sort = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondStack")
        {
            Player.Instance.presistentData.Stack = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondQueue")
        {
            Player.Instance.presistentData.Queue = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondLinkedList")
        {
            Player.Instance.presistentData.Queue = true;
            Destroy(collision.gameObject);
        }
    }

 }
