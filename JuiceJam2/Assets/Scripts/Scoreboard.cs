using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreBoardText;

    // Update is called once per frame
    public void Update()
    {
        //scorhandler add/update/display
        scoreBoardText.text = $"SCORE: {ScoreHandler.Instance.Score}";
    }
}
