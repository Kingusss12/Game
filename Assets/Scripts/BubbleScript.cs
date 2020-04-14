using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleScript: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator anim;
    public GameObject bubble;

    public void OnPointerEnter(PointerEventData eventData)
    {

        anim = bubble.GetComponent<Animator>();
        anim.SetBool("isActive", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim = bubble.GetComponent<Animator>();
        anim.SetBool("isActive", false);


    }

}
