using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDiamondFromLevel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.presistentData.TreeTraversal) Destroy(GameObject.FindGameObjectWithTag("DiamondTreeTraversal"));
        if (Player.Instance.presistentData.BinarySearchTree) Destroy(GameObject.FindGameObjectWithTag("DiamondBinarySearchTree"));
        if (Player.Instance.presistentData.Sort) Destroy(GameObject.FindGameObjectWithTag("DiamondSort"));
        if (Player.Instance.presistentData.Stack) Destroy(GameObject.FindGameObjectWithTag("DiamondStack"));
        if (Player.Instance.presistentData.Queue) Destroy(GameObject.FindGameObjectWithTag("DiamondQueue"));
        if (Player.Instance.presistentData.LinkedList) Destroy(GameObject.FindGameObjectWithTag("DiamondLinkedList"));

    }
}
