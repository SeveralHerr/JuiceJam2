using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;

public class Gameover : MonoBehaviour
{
    [SerializeField]
    internal float targetTime = 20.0f;
    private Random _random => new Random();

    [SerializeField]
    private int BiteCount;

    [SerializeField]
    internal int WaitTime = 20;


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
            UnityEngine.SceneManagement.SceneManager.LoadScene("Death");

        }
    }

    void timerEnded()
    {
        WaitTime -= 1;

        if (WaitTime <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
        }
    }
}
