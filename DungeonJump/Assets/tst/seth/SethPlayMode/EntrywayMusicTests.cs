/*
 * Filename: EntrywayMusicTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests the music calling of EntrywayExit and EntrywayEnter.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests the music calling of EntrywayExit and EntrywayEnter.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test.   
 */
public class EntrywayMusicTests: MonoBehaviour
{
    public string testScene = "OverworldGrungieArea";

    /*
     * Summary: Load test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(testScene);
    }

    /*
     * Summary: Function testing EntrywayEnter's PlayMusic().
     * 
     */
    [UnityTest]
    public IEnumerator EntryMusicTest()
    {
        //ARRANGE

        //wait for scene to load:
        yield return new WaitForSeconds(2);

        //find entryway and its building music:
        EntrywayEnter[] entrywaysEnterable = GameObject.FindObjectsOfType<EntrywayEnter>();

        int i;

        for ( i = 0; entrywaysEnterable[i].buildingMusic == null; i++) ;

        AudioSource audioSrc = entrywaysEnterable[i].buildingMusic;

        //if no audio src clip:
        if ( audioSrc.clip == null)
        {
            Assert.Inconclusive("No clip to play music so can't test.");
        }

        //clear building music:
        entrywaysEnterable[i].buildingMusic = null;

        //ACT

        //try to play music w/o music attached: (shouldn't error)
        entrywaysEnterable[i].PlayMusic();

        //re-add music:
        entrywaysEnterable[i].buildingMusic = audioSrc;

        //now try to play music:
        entrywaysEnterable[i].PlayMusic();

        //wait for music to start:
        yield return new WaitForSeconds(0.1f);

        //ASSERT

        Debug.Log(entrywaysEnterable[i].buildingMusic.name + " is playing: " + entrywaysEnterable[i].buildingMusic.isPlaying);

        //if music is playing
        Assert.IsTrue(entrywaysEnterable[i].buildingMusic.isPlaying);

        yield return null;
    }

    /*
     * Summary: Function testing EntrywayExit's PauseMusic().
     * 
     */
    [UnityTest]
    public IEnumerator ExitMusicTest()
    {
        //ARRANGE

        //wait for scene to load:
        yield return new WaitForSeconds(2);

        //find entryway and its building music:
        EntrywayExit[] entrywaysExitable = GameObject.FindObjectsOfType<EntrywayExit>();

        int i;

        for (i = 0; entrywaysExitable[i].buildingMusic == null; i++) ;

        AudioSource audioSrc = entrywaysExitable[i].buildingMusic;

        //if no audio src clip:
        if (audioSrc.clip == null)
        {
            Assert.Inconclusive("No clip to play music so can't test.");
        }

        //clear building music:
        entrywaysExitable[i].buildingMusic = null;

        //ACT

        //try to pause music w/o music attached: (shouldn't error)
        entrywaysExitable[i].PauseMusic();

        //re-add music:
        entrywaysExitable[i].buildingMusic = audioSrc;

        //play music:
        entrywaysExitable[i].buildingMusic.Play();

        //wait to start playing:
        yield return new WaitForSeconds(0.1f);

        //now try to pause music:
        entrywaysExitable[i].PauseMusic();

        //wait for music to stop:
        yield return new WaitForSeconds(0.1f);

        //ASSERT

        Debug.Log(entrywaysExitable[i].buildingMusic.name + " is playing: " + entrywaysExitable[i].buildingMusic.isPlaying);

        //if music isn't playing
        Assert.IsFalse(entrywaysExitable[i].buildingMusic.isPlaying);

        yield return null;
    }
}