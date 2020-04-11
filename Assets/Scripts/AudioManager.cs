using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioClip CoinCollected;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        CoinCollected = Resources.Load<AudioClip>("CoinCollected");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void playCoinCollected()
    {
        audioSrc.PlayOneShot(CoinCollected);
    }
}
