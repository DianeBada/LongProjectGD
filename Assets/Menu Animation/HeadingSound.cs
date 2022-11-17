using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadingSound : MonoBehaviour
{
    //Audio source
    public AudioSource headingAudio;

    void Update()
    {
        StartCoroutine(SoundEffect());
    }

    private IEnumerator SoundEffect()
    {
        yield return new WaitForSeconds(5f);
        headingAudio.Play();
    }
}
