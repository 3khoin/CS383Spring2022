/*
* Filename: AudioManager.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the audio manager singleton
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
* Summary: The AudioManager class which manages SFX
*
* Member Variables:
* sounds - a list of sound effects
* instance - the singleton
*/
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    /*
    * Summary: Initialize an AudioManager singleton
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void Awake()
    {
        // Singleton code for AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /*
    * Summary: Play a sound clip
    *
    * Parameters:
    * name - name of the sound clip
    *
    * Returns:
    * none
    */
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // don't do anything if the sound doesn't exist
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
}
