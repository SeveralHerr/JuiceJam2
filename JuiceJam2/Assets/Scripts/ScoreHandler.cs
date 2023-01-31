using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[SerializeField]
public class ScoreHandler : SingletonMonobehavior<ScoreHandler>
{
    [SerializeField]
    public int Score = 0;
    
    public void AddScore (int score)
    {
        Score = Score + score;
    }
}
