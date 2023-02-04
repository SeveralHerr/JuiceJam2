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

    public Eyes Eyes;

    public Animator BiteAnimator;


    // Update is called once per frame
    void Update()
    {
        if (!IsGameRunning.Instance.isRunning)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Animator.Play("Poke");
        }
    }


    public void PokeAnimationEnded()
    {
        _Gameover.targetTime = 20;
        pokeSound.Play();
        if (Eyes.EyeAction == EyeBehavior.LeftEye || Eyes.EyeAction == EyeBehavior.RightEye)
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