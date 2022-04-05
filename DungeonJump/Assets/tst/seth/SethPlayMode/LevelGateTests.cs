/*
 * Filename: LevelGateTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests 
 * 
 * Member Variables:
 * testScene - string name of scene being used to test. 
 */
public class LevelGateTests
{
    public string testScene = "OverworldSpawnArea";

    /*
     * Summary: Loads test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(testScene);
    }

    /*
     * Summary: Make sure scene changes when player is teleported onto a random level gate
     *          located in the test scene.
     * 
     */
    [UnityTest]
    public IEnumerator ChangeSceneTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        //get current scene name:
        string initSceneName = SceneManager.GetActiveScene().name;

        //find level gate obj:
        GameObject lvlGateObj = GameObject.FindObjectOfType<LevelGate>().gameObject;
        yield return null;

        //make sure player and level gate on the same layer
        GameObject.FindGameObjectWithTag("Player").layer = lvlGateObj.layer;
        yield return null;

        //ACT

        //set player to level gate location:
        GameObject.FindGameObjectWithTag("Player").transform.position = lvlGateObj.transform.position;

        yield return null;

        //ASSERT

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        Debug.Log("Old scene: " + initSceneName);
        Debug.Log("New scene: " + SceneManager.GetActiveScene().name);

        //make sure scene has been changed:
        Assert.IsTrue(initSceneName != SceneManager.GetActiveScene().name);
    }
    
}