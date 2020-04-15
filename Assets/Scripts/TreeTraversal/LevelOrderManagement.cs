using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 This script manages the functinality of LevelOrder mission
 The elements List contains the correct order
 The TouchedElements by the player are stored in the touchedElements list
 The script compares the elements thanks to the indexes in each step
 If there is match -> player traversed the tree in correct way else player loose life
     */

public class LevelOrderManagement : MonoBehaviour
{

    public List<Collider2D> Elements = new List<Collider2D>();
    public GateScript NextGate;
    public HelpScript Help;
    private int progress;
    private static int helpProgress = 0;

    public Text wrongStep;

    public void Start()
    {

    }

    public void OnTouch(Collider2D obj)
    {
        if (Elements[progress] == obj)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
            AudioManager.playGoodStep();
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
            progress = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].GetComponent<CollisionDetection>().Reset();
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
