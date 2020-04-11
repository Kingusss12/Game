using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject escapeCanvas, DiamondTreeTraversal, DiamondBinarySearchTree, DiamondSort, DiamondStack, DiamondQueue, DiamondLinkedList;

    void Start()
    {
        if (Player.Instance.treeTraversal)
        {
            DiamondTreeTraversal.gameObject.SetActive(true);
        }
        if (Player.Instance.binarySearchTree)
        {
            DiamondBinarySearchTree.gameObject.SetActive(true);
        }
        if (Player.Instance.sort)
        {
            DiamondSort.gameObject.SetActive(true);
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

    public void ExitEscape()
    {
        escapeCanvas.gameObject.SetActive(false);
    }

    public void SaveAndLeave()
    {
        SaverScript.SavePlayer(Player.Instance.lives, Player.Instance.coins, Player.Instance.treeTraversal,
                Player.Instance.binarySearchTree, Player.Instance.sort, Player.Instance.stack,
                Player.Instance.queue, Player.Instance.linkedList, Player.Instance.gameIsSaved);
        SceneManager.LoadScene("MainScreen");
        escapeCanvas.gameObject.SetActive(false);
    }




}
