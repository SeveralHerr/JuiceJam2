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
    private int MaxPokeCount;
    public SpriteRenderer Bite;

    [SerializeField]
    internal int WaitTime = 20;

    public Heads Heads;


    // Start is called before the first frame update
    void Start()
    {
        WaitTime = 20;
        MaxPokeCount = _random.Next(10, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsGameRunning.Instance.isRunning)
        {
            return;
        }

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
       

        if (ScoreHandler.Instance.Score >= MaxPokeCount)
        {
            biteSound.Play();
            GetBit();
        }

        if(ScoreHandler.Instance.Score >= MaxPokeCount * 0.5f )
        {
            Heads.SetAngry();
        }
    }

    void timerEnded()
    {
        WaitTime -= 1;

        if (WaitTime <= 0)
        {
            biteSound.Play();
            GetBit();

            WaitTime = 4423;
        }
    }

    public void GetBit()
    {
        Bite.enabled = true;
        BiteAnimator.Play("Bite");
    }

    public void DisableBiteAnimation()
    {
        Bite.enabled = false;
    }
}
