/*
 * Filename: LevelManagerTests.cs 
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
 * 
 */
public class LevelManagerTests
{
    public string testScene = "OverworldSpawnArea";

    private Vector2 playerPos;

    private LevelManager lvlMngerInstance;

    //LevelManager

    /*
     * Summary: Loads test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {
        //testing starting scene:
        SceneManager.LoadScene(testScene);

        //get a LevelManager instance:
        lvlMngerInstance = LevelManager.Instance;
    }

    /*
     * Summary: 
     * 
     * Notes: 
     * A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
     * `yield return null;` to skip a frame.
     */
    [UnityTest]
    public IEnumerator ProgBlocksTest()
    {
        //ARRANGE

        //find all progress blocks in curr scene:
        GameObject[] progBlocks = GameObject.FindGameObjectsWithTag("ProgBlock");

        //ACT

        //remove curr scene's prog blocks:
        lvlMngerInstance.RemoveProgressBlocks();

        //allow frame pass:
        yield return null;

        //Change scene:
        SceneManager.LoadScene("OverworldDemoScene");

        //SceneManager.GetActiveScene().buildIndex+1);

        yield return null;

        //Change scene back:
        SceneManager.LoadScene(testScene);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert

    }
}