using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using Random = System.Random;

public class DeathStuff : MonoBehaviour
{
    public GameObject DeathScreen;
    public SpriteRenderer Bite;

    [SerializeField]
    private float targetTime = 1.0f;

    private bool RunOnceTimer = false;

    private void Start()
    {
        targetTime = 1f;
    }
    public void Death()
    {
        Bite.enabled = false;
        DeathScreen.SetActive(true);
        IsGameRunning.Instance.isRunning = false;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
    }

    private void Update()
    {
        Debug.Log(IsGameRunning.Instance.isRunning);
        if (IsGameRunning.Instance.isRunning)
        {
            return; 
        }

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    private void timerEnded()
    {
        if(RunOnceTimer)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RunOnceTimer = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}