using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toot : MonoBehaviour
{
    public GameObject TootImage;
    public AudioSource TootSound;

    bool isFirstRun = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoToot());
    }

    // Update is called once per frame
    void Update()
    {
        if(!TootSound.isPlaying)
        {
            TootImage.SetActive(false);
        }
    }

    private IEnumerator DoToot()
    {
        while (IsGameRunning.Instance.isRunning)
        {

            //if (isFirstRun)
            //{
            //    isFirstRun = false;
            //    yield break;
            //}
            TootImage.SetActive(true);
            TootSound.Play();

            yield return new WaitForSeconds(UnityEngine.Random.Range(9f, 15f));
        }
    }
}
