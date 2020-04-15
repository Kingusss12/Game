using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public List<Collider2D> Elements = new List<Collider2D>();
    public GateScript NextGate;
    public HelpScript Help;
    private int progress;
    private static int helpProgress = 0;
    public static bool noChild = false;

    public Text wrongStep;


    public void OnTouch(Collider2D obj)
    {
        if (Elements[progress] == obj)
        {
            AudioManager.playGoodStep();
            obj.GetComponent<Renderer>().material.color = Color.green;
            if(obj.transform.childCount == 0)
            {
                noChild = true;
                obj.gameObject.SetActive(false);
            }
            else obj.transform.GetChild(0).gameObject.SetActive(true);
            progress++;
            if (progress == Elements.Count)
            {
                if (!NextGate.IsOpen)
                {
                    NextGate.Open();
                    Help.Open();
                    helpProgress++;
                }
            }
        }
        else
        {
            StartCoroutine(WrongStep());
            Player.Instance.Die();
            noChild = false;
            progress = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].GetComponent<LinkedListCollison>().Reset();
                if (Elements[i].transform.childCount > 0)
                     Elements[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            print("Wrong step!");
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
