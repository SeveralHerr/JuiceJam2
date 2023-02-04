using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal enum HeadBehavior
{
    NormalHead,
   // AngryNormalHead,
    LeftHead,
   RightHead,
  //  AngryLeftHead,
   // AngryRightHead
}

public class Heads : MonoBehaviour
{
    [SerializeField] private GameObject LeftHead;
    [SerializeField] private GameObject RightHead;
    [SerializeField] private GameObject AngryLeftHead;
    [SerializeField] private GameObject AngryRightHead;
    [SerializeField] private GameObject NormalHead;
    [SerializeField] private GameObject AngryNormalHead;

    [SerializeField]
    internal HeadBehavior HeadAction;

    private Dictionary<HeadBehavior, GameObject> HeadMap;
    private void Awake()
    {
        HeadMap = new Dictionary<HeadBehavior, GameObject>
        {
            { HeadBehavior.LeftHead, LeftHead },
            { HeadBehavior.RightHead, RightHead },
            { HeadBehavior.NormalHead, NormalHead },
          //  { HeadBehavior.AngryLeftHead, AngryLeftHead },
           // { HeadBehavior.AngryRightHead, AngryRightHead },
            //{ HeadBehavior.AngryNormalHead, AngryNormalHead },
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeHeadBehavior());
    }

    private IEnumerator ChangeHeadBehavior()
    {
        while(IsGameRunning.Instance.isRunning)
        {
            HeadAction = (HeadBehavior)UnityEngine.Random.Range(0, 3);
            foreach (var head in HeadMap)
            {
                head.Value.SetActive(false);
            }

            HeadMap[HeadAction].SetActive(true);

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetAngry()
    {
        HeadMap[HeadBehavior.NormalHead] = AngryNormalHead;
        HeadMap[HeadBehavior.LeftHead] = AngryLeftHead;
        HeadMap[HeadBehavior.RightHead] = AngryRightHead;

        if (LeftHead.activeSelf)
        {
            AngryLeftHead.SetActive(true);
        }

        if(RightHead.activeSelf)
        {
            AngryRightHead.SetActive(true);
        }

        if(NormalHead.activeSelf)
        {
            AngryNormalHead.SetActive(true);
        }

        LeftHead.SetActive(false);
        RightHead.SetActive(false);
        NormalHead.SetActive(false);
    }
}
