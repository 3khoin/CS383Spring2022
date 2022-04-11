/*
 * Filename: LayerTriggerTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests changing the player's layer through a trigger.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Cainos.PixelArtTopDown_Basic;

/*
 * Summary: Class tests changing the player's layer through a trigger.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test. 
 */
public class LayerTriggerTests
{
    public string testScene = "OverworldSpawnArea";

    public int testSpeedY = 10;

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
     * Summary: Incrementally increases player speed until layer doesn't change.
     *          Currently inconclusive because player movement is difficult to simulate in tests.
     * 
     */
    [UnityTest]
    public IEnumerator PlayerSpeedTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(2f);

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

    /*
      * Summary: Checks if layer trigger changes player's layer when player exits it.
      * 
      */
    [UnityTest]
    public IEnumerator LayerSwitchTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(2f);

        //find arbitrary level trigger obj:
        //since script namespaced, have to access as such
        GameObject layerTriggerObj = GameObject.FindObjectOfType<Cainos.PixelArtTopDown_Basic.LayerTrigger>().gameObject;
        yield return null;

        //make sure player and layer on the same layer
        GameObject.FindGameObjectWithTag("Player").layer = layerTriggerObj.layer;
        yield return null;

        //get player's current layer:
        int startingLayer = GameObject.FindGameObjectWithTag("Player").layer;

        //ACT

        //set player to layer trigger:
        GameObject.FindGameObjectWithTag("Player").transform.position = layerTriggerObj.transform.position;

        yield return new WaitForSeconds(0.5f);

        //change layer trigger to somewhere else:
        layerTriggerObj.transform.position += new Vector3( 0, 10, 0 );

        yield return new WaitForSeconds(0.5f);

        //get what layer player ended up on:
        int endingLayer = GameObject.FindGameObjectWithTag("Player").layer;

        //ASSERT

        Debug.Log("Player's old layer: " + startingLayer);
        Debug.Log("Player's new layer: " + endingLayer);

        //make sure player layer has been changed:
        Assert.IsTrue(startingLayer != endingLayer);
    }

}