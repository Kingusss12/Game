using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public static class SaverScript  {

    public static void SavePlayer(int coins, int lives, bool treeTraversal, bool binarySearchTree, bool sort, bool stack, bool queue, bool linkedList, bool gameIsSaved)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ITAdventure.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(coins,lives, treeTraversal, binarySearchTree, sort, stack, queue, linkedList, gameIsSaved);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bin";
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
            return null;
        }
    }
    
}
