/*
 * Filename: LayerTriggerTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests 
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Cainos.PixelArtTopDown_Basic;

/*
 * Summary: Class tests 
 * 
 * Member Variables:
 * testScene - string name of scene being used to test. 
 */
public class LayerTriggerTests
{
    public string testScene = "OverworldSpawnArea";

    public int testSpeedY = 100;

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
    public IEnumerator PlayerSpeedTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        //get player's current layer:
        int startingLayer = GameObject.FindGameObjectWithTag("Player").layer;

        //find arbitrary level trigger obj:
        //since script namespaced, have to access as such
        GameObject layerTriggerObj = GameObject.FindObjectOfType<Cainos.PixelArtTopDown_Basic.LayerTrigger>().gameObject;
        yield return null;

        //make sure player and level gate on the same layer
        //GameObject.FindGameObjectWithTag("Player").layer = lvlGateObj.layer;
        yield return null;

        //ACT

        //set player to south of layer trigger:
        GameObject.FindGameObjectWithTag("Player").transform.position = layerTriggerObj.transform.position + new Vector3(0, -2, 0);


        //move player across layer trigger by applying velocity:
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2( 0, testSpeedY);

        yield return null;

        //apply an impulse:
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0, testSpeedY), ForceMode2D.Impulse);

        //wait for player to cross trigger:
        yield return new WaitForSeconds(0.5f);

        //get what layer player ended up on:
        int endingLayer = GameObject.FindGameObjectWithTag("Player").layer;

        //ASSERT

        Debug.Log("Player's old layer: " + startingLayer);
        Debug.Log("Player's new layer: " + endingLayer);

        //placeholder:
        Assert.Inconclusive("Test unfinished because can't automate player movement properly");

        //make sure player layer has been changed:
        //Assert.IsTrue(startingLayer != endingLayer);
    }

}