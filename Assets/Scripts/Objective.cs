using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public List<GameItem> Elements = new List<GameItem>();
    public UnityEngine.Events.UnityEvent OnSuccess;
    public bool PreserveOrder;
    public int progress;

    public bool IsComplete
    {
        get
        {
            return progress == Elements.Count;
        }
    }

    public void Start()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            print(Elements[i]);
        }
    }

    public void RegisterEvent(GameItem obj)
    {
        if (IsComplete)
            return;
        if (PreserveOrder)
        {
            if (Elements[progress] == obj)
            {
                progress++;
                if (IsComplete)
                {
                    OnSuccess.Invoke();
                }
            }
            else
            {
                Reset();
            }
        }
        else
        {
            Debug.Log("lol2");

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == obj)
                {
                    Debug.Log("lol");
                    progress++;
                    if (IsComplete)
                    {
                        OnSuccess.Invoke();
                    }
                }
            }
        }
        
    }

    public void Reset()
    {
        Player.Instance.Die();

        progress = 0;
        for (int i = 0; i < Elements.Count; i++)
        {
            Elements[i].GetComponent<GameItem>().Reset();
        }
    }
}
