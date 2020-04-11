using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    private void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("HeartPulsing", 0, Random.Range(0.0f, 1f));
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Player.Instance.lives++;
            Destroy(gameObject);
            AudioManager.playCoinCollected();
        }
    }
}
