using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DiamondTreeTraversal")
        {
            Player.Instance.treeTraversal = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondBinarySearchTree")
        {
            Player.Instance.binarySearchTree = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondSort")
        {
            Player.Instance.sort = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondStack")
        {
            Player.Instance.stack = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondQueue")
        {
            Player.Instance.queue = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DiamondLinkedList")
        {
            Player.Instance.linkedList = true;
            Destroy(collision.gameObject);
        }
    }

 }
