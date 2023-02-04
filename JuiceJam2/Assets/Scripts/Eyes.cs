using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Eyes : MonoBehaviour
{

    public GameObject LeftEye;
    public GameObject RightEye;
    public GameObject RegularEye;

    [SerializeField]
    internal EyeBehavior EyeAction;

    [SerializeField]
    private float timeBetweenEyeMovements = 10f;


    // Start is called before the first frame update
    void Start()
    {
        SetEyeBehavior();
        SetTimeBetweenEyeMovements();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenEyeMovements -= Time.deltaTime;

        if (timeBetweenEyeMovements <= 0.0f)
        {
            timerEnded();
        }
    }

    private void timerEnded()
    {
        SetEyeBehavior();
        SetTimeBetweenEyeMovements();
    }

    private void SetTimeBetweenEyeMovements()
    { 
        timeBetweenEyeMovements = Random.Range(0.5f, 1.5f);
    }
    
    private void SetEyeBehavior()
    {
        EyeAction = (EyeBehavior)Random.Range(0, 3);

        switch (EyeAction)
        {

            case EyeBehavior.LeftEye:
                RegularEye.SetActive(false);
                LeftEye.SetActive(true);
                RightEye.SetActive(false);
                break;
            case EyeBehavior.RightEye:
                RegularEye.SetActive(false);
                LeftEye.SetActive(false);
                RightEye.SetActive(true);
                break;
            // case EyeBehavior.RegularEye:
            default:
                RegularEye.SetActive(true);
                LeftEye.SetActive(false);
                RightEye.SetActive(false);
                break;
        }

    }
}

internal enum EyeBehavior
{ 
    RegularEye,
    LeftEye,
    RightEye
}
