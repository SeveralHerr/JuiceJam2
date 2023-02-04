using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreBoardText;

    public Text scoreBoardText2;
    public Text Text;


    // Update is called once per frame
    public void Update()
    {
        //scorhandler add/update/display
        scoreBoardText2.text = $"SCORE: {ScoreHandler.Instance.Score}";
        Text.text = $"SCORE: {ScoreHandler.Instance.Score}";
    }
}
