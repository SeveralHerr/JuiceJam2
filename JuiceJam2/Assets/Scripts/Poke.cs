using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Poke : MonoBehaviour
{
    public Gameover _Gameover;

    public AudioSource pokeSound;
    public AudioSource biteSound;

    public Animator Animator;
    public SpriteRenderer Bite;

    public Heads Heads;

    public Animator BiteAnimator;

    public float clickRateLimit = 0.2f;
    private float lastClickTime;


    // Update is called once per frame
    void Update()
    {
        if (!IsGameRunning.Instance.isRunning)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < clickRateLimit)
            {
                Debug.Log("Too fast! Limiting clicks...");
                return;
            }
            lastClickTime = Time.time;

            Animator.Play("Poke");
            //Stick.SetMove();
        }
    }


    public void PokeAnimationEnded()
    {
        _Gameover.targetTime = 20;
        pokeSound.Play();
        if (Heads.HeadAction == HeadBehavior.LeftHead || Heads.HeadAction == HeadBehavior.RightHead)
        {
            ScoreHandler.Instance.AddScore(1);
            Animator.Play("Unpoke");
        }
        else
        {
            biteSound.Play();
            GetBit();
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