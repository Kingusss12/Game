using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDiamondFromLevel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.treeTraversal) Destroy(GameObject.FindGameObjectWithTag("DiamondTreeTraversal"));
        if (Player.Instance.binarySearchTree) Destroy(GameObject.FindGameObjectWithTag("DiamondBinarySearchTree"));
        if (Player.Instance.sort) Destroy(GameObject.FindGameObjectWithTag("DiamondSort"));
        if (Player.Instance.stack) Destroy(GameObject.FindGameObjectWithTag("DiamondStack"));
        if (Player.Instance.queue) Destroy(GameObject.FindGameObjectWithTag("DiamondQueue"));
        if (Player.Instance.linkedList) Destroy(GameObject.FindGameObjectWithTag("DiamondLinkedList"));

    }
}
