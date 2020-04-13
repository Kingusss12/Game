using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  This script handles the World screen
    It is applied to the player
     */

public class LevelManager : MonoBehaviour
{

    public GameObject TreeTraversal, BinarySearchTree, Sort, Stack, LinkedList, Queue;
    public GameObject level1, level2, level3, level4, level5, level6, level7;
    public GameObject level1Shine, level2Shine, level3Shine, level4Shine, level5Shine, level6Shine, bonusShine;
    private bool treeTraversal = false;
    private bool binarySearchTree = false;
    private bool sort = false;
    private bool stack = false;
    private bool linkedlist = false;
    private bool queue = false;


    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            GoToLevel();
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "treeTraversal":
                treeTraversal = true;
                TreeTraversal.gameObject.SetActive(true);
                level1.SetActive(false);
                level1Shine.SetActive(true);
                break;
            case "binarySearchTree":
                binarySearchTree = true;
                BinarySearchTree.gameObject.SetActive(true);
                level2Shine.SetActive(true);
                level2.SetActive(false);
                break;
            case "sort":
                sort = true;
                Sort.gameObject.SetActive(true);
                level3Shine.SetActive(true);
                level3.SetActive(false);
                break;
            case "stack":
                stack = true;
                Stack.gameObject.SetActive(true);
                level4Shine.SetActive(true);
                level4.SetActive(false);
                break;
            case "linkedList":
                linkedlist = true;
                LinkedList.gameObject.SetActive(true);
                level5Shine.SetActive(true);
                level5.SetActive(false);
                break;
            case "queue":
                queue = true;
                Queue.gameObject.SetActive(true);
                level6Shine.SetActive(true);
                level6.SetActive(false);
                break;
            default:
                break;
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "treeTraversal":
                treeTraversal = false;
                TreeTraversal.gameObject.SetActive(false);
                level1Shine.SetActive(false);
                level1.SetActive(true);
                break;
            case "binarySearchTree":
                binarySearchTree = false;
                BinarySearchTree.gameObject.SetActive(false);
                level2Shine.SetActive(false);
                level2.SetActive(true);
                break;
            case "sort":
                sort = false;
                Sort.gameObject.SetActive(false);
                level3Shine.SetActive(false);
                level3.SetActive(true);
                break;
            case "stack":
                stack = false;
                Stack.gameObject.SetActive(false);
                level4Shine.SetActive(false);
                level4.SetActive(true);
                break;
            case "linkedList":
                linkedlist = false;
                LinkedList.gameObject.SetActive(false);
                level5Shine.SetActive(false);
                level5.SetActive(true);
                break;
            case "queue":
                queue = false;
                Queue.gameObject.SetActive(false);
                level6Shine.SetActive(false);
                level6.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void GoToLevel()
    {
        if (treeTraversal)  SceneManager.LoadScene("TreeTraversal");
        if (binarySearchTree)   SceneManager.LoadScene("BinarySearchTree");
        if (sort)   SceneManager.LoadScene("Sort");
        if (stack) SceneManager.LoadScene("Stack");
        if (queue) SceneManager.LoadScene("Queue");
        if (linkedlist) SceneManager.LoadScene("LinkedList");
    }


}
