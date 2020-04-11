using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable] //save it in file
public class PlayerData
{
    public int Coins, Lives;
    public bool TreeTraversal, BinarySearchTree, Sort, Queue, Stack, LinkedList, GameIsSaved;

    public PlayerData(int lives, int coins, bool treeTraversal, bool binarySearchTree, bool sort, bool stack, bool queue, bool linkedList, bool gameIsSaved)
    {

        Coins = coins;
        Lives = lives;
        TreeTraversal = treeTraversal;
        BinarySearchTree = binarySearchTree;
        Sort = sort;
        Stack = stack;
        Queue = queue;
        LinkedList = linkedList;
        GameIsSaved = gameIsSaved;

    }


    
}

