using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable] //save it in file
public class PlayerData
{
    public int Coins, Lives;
    public bool TreeTraversal, BinarySearchTree, Sort, Queue, Stack, LinkedList;

    public PlayerData(int lives, int coins, bool treeTraversal, bool binarySearchTree, bool sort, bool stack, bool queue, bool linkedList)
    {

        Coins = coins;
        Lives = lives;
        TreeTraversal = treeTraversal;
        BinarySearchTree = binarySearchTree;
        Sort = sort;
        Stack = stack;
        Queue = queue;
        LinkedList = linkedList;


    }

    public PlayerData() : this(5, 50, false, false, false, false, false, false)
    {

    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ITAdventure.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
       
        formatter.Serialize(stream, this);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/ITAdventure.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("File not found in " + path);
            return new PlayerData();

        }
    }
}

