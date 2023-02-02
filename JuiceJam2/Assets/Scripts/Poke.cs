using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Poke : MonoBehaviour {
    public Gameover _Gameover;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            // move the bear to the right
            _Gameover.targetTime = 20;
            ScoreHandler.Instance.AddScore(1);
        }
    }
}
