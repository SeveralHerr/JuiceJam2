using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Poke : MonoBehaviour 
{
    public Gameover _Gameover;

    public Eyes Eyes;

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
            if (Eyes.EyeAction == EyeBehavior.LeftEye || Eyes.EyeAction == EyeBehavior.RightEye)
            {
                ScoreHandler.Instance.AddScore(1);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Death");
            }
        }
    }
}
