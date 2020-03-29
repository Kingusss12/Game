using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public void Start()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            print(Elements[i]);
        }
    }

    public void OnTouch(Collider2D obj)
    {
        if (Elements[progress] == obj)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
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
            Player.Instance.Die();
            progress = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].GetComponent<CollisionDetection>().Reset();
            }
            print("Wrong step!");
        }
    }

    private void Update()
    {


    }
}
