using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public List<GameItem> Elements = new List<GameItem>();
    public UnityEngine.Events.UnityEvent OnSuccess;
    public UnityEngine.Events.UnityEvent OnFail;
    public bool PreserveOrder;
    public int progress;
    public Text wrongStep;


    public bool IsComplete
    {
        get
        {
            return progress == Elements.Count;
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
                AudioManager.playGoodStep();
                progress++;
                if (IsComplete)
                {
                        OnSuccess.Invoke();
                }
            }
            else
            {
                Reset();
                progress = 0;
                Player.Instance.Die();
                
            }
        }
        else
        {

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == obj)
                {
                    AudioManager.playGoodStep();
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
        StartCoroutine(WrongStep());
        progress = 0;
        OnFail.Invoke();
        for (int i = 0; i < Elements.Count; i++)
        {
            Elements[i].Reset();
        }
    }

    public IEnumerator WrongStep()
    {
        AudioManager.playWrongStep();
        wrongStep.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrongStep.gameObject.SetActive(false);
    }

}
