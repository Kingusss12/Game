using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  This script handles the World screen
    It is applied to the player
     */

public class LevelManager : MonoBehaviour
{

    public GameObject TreeTraversal, BinarySearchTree, Sort;
    private bool treeTraversal = false;
    private bool binarySearchTree = false;
    private bool sort = false;


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
                break;
            case "binarySearchTree":
                binarySearchTree = true;
                BinarySearchTree.gameObject.SetActive(true);
                break;
            case "sort":
                sort = true;
                Sort.gameObject.SetActive(true);
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
                break;
            case "binarySearchTree":
                binarySearchTree = false;
                BinarySearchTree.gameObject.SetActive(false);
                break;
            case "sort":
                sort = false;
                Sort.gameObject.SetActive(false);
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
    }


}
