using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Poke : MonoBehaviour {

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

            ScoreHandler.Instance.AddScore(1);
            Debug.Log(ScoreHandler.Instance.Score);
        }
    }
}
