using System.Collections;
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

    Color lightGreen;

    public void Start()
    {
        lightGreen = new Color(0.436f, 0.849f, 0.442f);
    }

    public void OnTouch(Collider2D obj)
    {
        if (Elements[progress] == obj)
        {
            AudioManager.playGoodStep();
            obj.GetComponent<Renderer>().material.color = lightGreen;
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

    public IEnumerator WrongStep()
    {
        AudioManager.playWrongStep();
        wrongStep.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrongStep.gameObject.SetActive(false);
    }
}
