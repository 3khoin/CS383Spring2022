/*
 * Filename: LevelManagerTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests LevelManager progress block removal and whether singleton is created on-demand.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests LevelManager progress block removal and whether singleton is created on-demand.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test.
 * lvlMngerInstance - LevelManager used to store manager's creation. 
 */
public class LevelManagerTests
{
    public string testScene = "OverworldSpawnArea";

    private LevelManager lvlMngerInstance;

    //LevelManager

    /*
     * Summary: Retrieves level manager instance.
     *  
     */
    [SetUp]
    public void Setup()
    {
        //get a LevelManager instance:
        lvlMngerInstance = LevelManager.Instance;
    }
    

    /*
     * Summary: Removes all the progress blocks in the current scene. Changes scenes, and then
     *          changes back. Verifies that progress blocks initially removed are still gone.
     * 
     * Notes: 
     * A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
     * `yield return null;` to skip a frame.
     */
    [UnityTest]
    public IEnumerator ProgBlocksTest()
    {
        //ARRANGE
        
        //testing starting scene:
        SceneManager.LoadScene(testScene);

        //ACT

        //remove curr scene's prog blocks:
        lvlMngerInstance.RemoveProgressBlocks();

        //allow frame pass:
        yield return null;

        //Use console to make sure scene actually changes:
        Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);

        //Change scene:
        SceneManager.LoadScene("OverworldDemoScene");

        //SceneManager.GetActiveScene().buildIndex+1);

        yield return null;

        Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);

        //yield return new WaitUntil(SceneManager.sceneLoaded);

        //Change scene back:
        SceneManager.LoadScene(testScene);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);

        //ASSERT

        //find all progress blocks in scene being tested:
        GameObject[] progBlocks = GameObject.FindGameObjectsWithTag("ProgBlock");

        //walk thru all prog blocks:
        for (int i = 0; i < progBlocks.Length; i++)
        {
            //make sure prog block is false:
            Assert.IsFalse(progBlocks[i].activeSelf);
        }
    }

    /*
     * Summary: Since level manager instance retrieved in setup, one should be in the scene.
     *          Make sure singlton is created on-demand.
     * 
     */
    [UnityTest]
    public IEnumerator SingletonOnDemandTest()
    {
        //ARRANGE

        yield return null;

        //ACT

        GameObject lvlMngerObj = GameObject.FindObjectOfType<LevelManager>().gameObject;

        //ASSERT

        yield return null;

        //should have found lvl manager obj in the scene:
        Assert.IsTrue(lvlMngerObj != null);
    }
    
}