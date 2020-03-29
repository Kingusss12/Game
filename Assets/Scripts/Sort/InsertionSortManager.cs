using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertionSortManager : MonoBehaviour
{
    public List<Collider2D> Elements = new List<Collider2D>();
    public GateScript NextGate;
    public HelpScript Help;
    public GameObject Comparison, Swap;
    public Text Num1, Num2;
    private int progress;

    Color[] colors = new Color[5];

    public void Start()
    {

        for (int i = 0; i < Elements.Count; i++)
        {
            print(Elements[i]);
        }

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
            obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];



            if (progress >= 1)
            {
                if (int.Parse(obj.gameObject.tag) > int.Parse(Elements[progress - 1].gameObject.tag))
                {
                    StartCoroutine(SwapText());
                    Vector2 temp = new Vector2(obj.transform.position.x, obj.transform.position.y);
                    obj.transform.position = Elements[progress - 1].transform.position;
                    Elements[progress - 1].transform.position = temp;

                }
                if (!(int.Parse(obj.gameObject.tag) == int.Parse(Elements[progress - 1].gameObject.tag)))
                {
                    print("Comparison:" + int.Parse(Elements[progress - 1].gameObject.tag) + " - " + int.Parse(obj.gameObject.tag));
                    Comparison.SetActive(true);
                    Num1.text = Elements[progress - 1].gameObject.tag.ToString();
                    Num2.text = Elements[progress].gameObject.tag.ToString();
                }
            }

            progress++;
            if (progress == Elements.Count)
            {
                Comparison.SetActive(false);
                if (!NextGate.IsOpen)
                {
                    NextGate.Open();
                    Help.Open();
                }
            }
        }
        else
        {
            Player.Instance.Die();
            progress = 0;
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
}
