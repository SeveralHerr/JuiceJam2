using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using Random = System.Random;

public class Gameover : MonoBehaviour
{
    [SerializeField]
    internal float targetTime = 20.0f;

   
    public AudioSource biteSound;

    public Animator BiteAnimator;

    private Random _random => new Random();

    [SerializeField]
    private int BiteCount;
    public SpriteRenderer Bite;

    [SerializeField]
    internal int WaitTime = 20;

    [SerializeField]
    internal BiteBehavior BiteAction;


    // Start is called before the first frame update
    void Start()
    {
        BiteCount = _random.Next(1, 50);
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
       

        if (ScoreHandler.Instance.Score >= BiteCount)
        {
            biteSound.Play();
            GetBit();
         //  StartCoroutine(WaitForSound());

        }
    }

    void timerEnded()
    {
        WaitTime -= 1;

        if (WaitTime <= 0)
        {
            biteSound.Play();
            GetBit();
            
        }
    }

    //IEnumerator WaitForSound()
    //{
    //    yield return new WaitWhile(() => biteSound.isPlaying);
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
    //}

    public void GetBit()
    {
        Bite.enabled = true;
        BiteAnimator.Play("Bite");

    }

    public void DisableBiteAnimation()
    {
        //StartCoroutine(WaitForSound());
        Bite.enabled = false;
    }

    internal enum BiteBehavior
    {
        NoBite,
        Bite
    }


    public void Death()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
    }
}
