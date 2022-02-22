using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public AudioSource buildingMusic;
    public GameObject roof;
    public Entryway[] buildingEntryways;

    private bool musicPlaying = false;
    private bool roofClear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //should both be called by entryway w/ ever player enters one

    //clear or opaque roof:
    public void InvertRoofAlpha()
    {
        if( roofClear )
        {
            //show roof:
            roof.SetActive(true);

            roofClear = false;
        }
        else
        {
            //dissapear roof:
            roof.SetActive(false);

            roofClear = true;
        }
    }

    //play or stop music:
    public void InvertMusicState()
    {
        if( musicPlaying )
        {
            //stop playering music:
            buildingMusic.Stop();

            musicPlaying = false;
        }
        else 
        {
            //play music:
            buildingMusic.Play();

            musicPlaying = true;
        }
    }
}
