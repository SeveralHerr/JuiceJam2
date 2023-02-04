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

    public float speed = 2.0f;
    public float reachDistance = 2.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool moveUpRight = true;

    private bool move = false;
    private bool reachedStartingPosition = false;

    public Animator BiteAnimator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(reachDistance, reachDistance, 0);
    }


    // Update is called once per frame
    void Update()
    {
        //if (move)
        //{
        //    if (moveUpRight)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        //        {
        //            moveUpRight = false;
        //            targetPosition = transform.position - new Vector3(reachDistance, reachDistance, 0);
        //        }
        //    }
        //    else
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        //        {
        //            moveUpRight = true;
        //            targetPosition = transform.position + new Vector3(reachDistance, reachDistance, 0);
        //        }
        //    }

        //    if (Vector3.Distance(transform.position, startPosition) < 0.1f && !reachedStartingPosition)
        //    {
        //        move = false;
        //        reachedStartingPosition = true;
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Animator.Play("Poke");
            //move = true;

            //if(reachedStartingPosition)
            //{
            //    reachedStartingPosition = false;
            //}

            //if (!moveUpRight)
            //{

          //  }

        }
    }

    //IEnumerator WaitForSound()
    //{
    //    yield return new WaitWhile(() => biteSound.isPlaying);
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
    //}

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
        //StartCoroutine(WaitForSound());
        Bite.enabled = false;

    }
}