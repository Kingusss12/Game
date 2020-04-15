﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SortOrderManagement : MonoBehaviour
{

    public List<Collider2D> Elements = new List<Collider2D>();
    public GateScript NextGate;
    public HelpScript Help;
    public GameObject Comparison, Swap;
    public Text Num1, Num2;
    public int progress;

    public Text wrongStep;

    Color[] colors = new Color[5];

    public void Start()
    {

        colors[0] = Color.green;
        colors[1] = new Color(0.436f, 0.849f, 0.442f);
        colors[2] = new Color(0.32f, 0.88f, 0.28f);
        colors[3] = new Color(0.37f, 0.77f, 0.34f);
        colors[4] = new Color(0.23f, 0.68f, 0.19f);
    }

    public void OnTouch(Collider2D obj)
    {
        if (Elements[progress] == obj)
        {
            AudioManager.playGoodStep();
            obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                       if (progress % 2 > 0)
            {
                bool earlier = obj.transform.localPosition.x < Elements[progress - 1].transform.localPosition.x;
                bool smaller = int.Parse(obj.gameObject.tag) < int.Parse(Elements[progress - 1].gameObject.tag);
                if ((smaller && !earlier) || (!smaller && earlier))
                {
                    StartCoroutine(SwapText());
                    Vector2 temp = new Vector2(obj.transform.position.x, obj.transform.position.y);
                    obj.transform.position = Elements[progress - 1].transform.position;
                    Elements[progress - 1].transform.position = temp;
                    SortCollisionDetection eScript = Elements[progress - 1].GetComponent<SortCollisionDetection>();
                    eScript.wasTouched = true;
                    eScript.OnCollisionLeave.AddListener(() =>
                    {
                        eScript.wasTouched = false;
                        eScript.OnCollisionLeave.RemoveAllListeners();
                    });
                }
                obj.GetComponent<Renderer>().sharedMaterial.color = Color.white;
                Elements[progress - 1].GetComponent<Renderer>().sharedMaterial.color = Color.white;
                Comparison.SetActive(true);   
                Num1.text = Elements[progress - 1].gameObject.tag.ToString();
                Num2.text = obj.gameObject.tag.ToString();
            }
            else
            {

            }

            progress++;
            if (progress == Elements.Count)
            {
                Comparison.SetActive(false);
                if (!NextGate.IsOpen)
                {
                    Num1 = null;
                    Num2 = null;
                    NextGate.Open();
                    Help.Open();
                }
            }
        }
        else
        {
            StartCoroutine(WrongStep());
            Player.Instance.Die();
            progress = 0;
            Num1.text = null;
            Num2.text = null;
            Comparison.SetActive(false);
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].GetComponent<SortCollisionDetection>().Reset();
            }
            print("Wrong step!");
        }
    }


    IEnumerator SwapText()
    {
        Swap.SetActive(true);
        yield return new WaitForSeconds(2f);
        Swap.SetActive(false);

    }

    private void OnLeave()
    {

    }

    private void SwapItem(Transform t1, Transform t2)
    {
        Vector3 pos = t1.localPosition;
        t1.localPosition = t2.localPosition;
        t2.localPosition = pos;
    }

    public IEnumerator WrongStep()
    {
        AudioManager.playWrongStep();
        wrongStep.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrongStep.gameObject.SetActive(false);
    }
}
