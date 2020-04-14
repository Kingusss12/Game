using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject escapeCanvas, DiamondTreeTraversal, DiamondBinarySearchTree, DiamondSort, DiamondStack, DiamondQueue, DiamondLinkedList;

    void Start()
    {
        if (Player.Instance.presistentData.TreeTraversal)
        {
            DiamondTreeTraversal.gameObject.SetActive(true);
        }
        if (Player.Instance.presistentData.BinarySearchTree)
        {
            DiamondBinarySearchTree.gameObject.SetActive(true);
        }
        if (Player.Instance.presistentData.Sort)
        {
            DiamondSort.gameObject.SetActive(true);
        }
        if (Player.Instance.presistentData.Stack)
        {
            DiamondStack.gameObject.SetActive(true);
        }
        if (Player.Instance.presistentData.LinkedList)
        {
            DiamondLinkedList.gameObject.SetActive(true);
        }
        if (Player.Instance.presistentData.Queue)
        {
            DiamondQueue.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If player push the "escape button, the player goes back to the MainScreen(Main Menu)"
        if (Input.GetKey(KeyCode.Escape))
        {
            escapeCanvas.gameObject.SetActive(true);
        }
    }

    /*
Saves player's data's like Live and coin amount to a binary file and navigates back to MainScene
*/

    public void BackToMainMenu()
    {
        PlayerData.Save();
        SceneManager.LoadScene(0);
    }

    public void ExitEscape()
    {
        escapeCanvas.gameObject.SetActive(false);
    }






}
