using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public static SceneLoaderScript Instance;
    public PlayerData PlayerData;



    public void Play()
    {
        SceneManager.LoadScene(1);
        PlayerData = new PlayerData(5, 50, false, false, false, false, false, false, false);

    }

    public void Awake()
    {

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void LoadPlayer()
    {

            PlayerData = PlayerData.Load();
            SceneManager.LoadScene(1);

    }

    
}
