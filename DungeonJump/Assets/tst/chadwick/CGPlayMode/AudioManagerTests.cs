/*
* Filename: AudioManagerTests.cs
* Developer: Chadwick Goodall
* Purpose: Testing the audio manager
*/

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class AudioManagerTests
{
    /*
    * Summary: Sets up the scene for testing
    */
    [SetUp]
    public void Setup()
    {   // load dummy scene
        SceneManager.LoadScene("CGStressTest");
    }


    [UnityTest]
    public IEnumerator AudioManagerPlaySound()
    {
        // Arrange
        string soundName = AudioManager.instance.sounds[0].name;
        yield return null;


        // Act
        // attempt to play the first sound available in the manager
        AudioManager.instance.Play(soundName);
        yield return null;

        // Assert
        // check to ensure that the first sound is not a null sound
        Assert.IsNotNull(AudioManager.instance.sounds[0]);
        yield return null;
    }
}
