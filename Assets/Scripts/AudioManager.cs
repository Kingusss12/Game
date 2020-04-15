using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioClip coinCollected, buttonClick, yay, select, wrongStep, noMoney, bugSplash, gateOpen, plusLife, goodStep;
 

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        coinCollected = Resources.Load<AudioClip>("CoinCollected");
        buttonClick = Resources.Load<AudioClip>("buttonClick");
        select = Resources.Load<AudioClip>("select");
        yay = Resources.Load<AudioClip>("yay");
        wrongStep = Resources.Load<AudioClip>("WrongStep");
        noMoney = Resources.Load<AudioClip>("NotEnoughMoney");
        bugSplash = Resources.Load<AudioClip>("bugSplash");
        gateOpen = Resources.Load<AudioClip>("gateOpen");
        plusLife = Resources.Load<AudioClip>("Life");
        goodStep = Resources.Load<AudioClip>("goodStep");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void playCoinCollected()
    {
        audioSrc.PlayOneShot(coinCollected);
    }

    public static void playButtonClick()
    {
        audioSrc.PlayOneShot(buttonClick);
    }

    public static void playSelect()
    {
        audioSrc.PlayOneShot(select);
    }

    public static void playYay()
    {
        audioSrc.PlayOneShot(yay);
    }
    public static void playWrongStep()
    {
        audioSrc.PlayOneShot(wrongStep);
    }

    public static void playNoMoney()
    {
        audioSrc.PlayOneShot(noMoney);
    }

    public static void playGateOpen()
    {
        audioSrc.PlayOneShot(gateOpen);
    }

    public static void playBugSplash()
    {
        audioSrc.PlayOneShot(bugSplash);
    }

    public static void playPlusLife()
    {
        audioSrc.PlayOneShot(plusLife);
    }

    public static void playGoodStep()
    {
        audioSrc.PlayOneShot(goodStep);
    }
}
