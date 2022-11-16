using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{

    public AudioSource levelMusic;
    // Start is called before the first frame update
    void Start()
    {
        levelMusic = GetComponent<AudioSource>();
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
