/*
 * Filename: InteractableTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests whether an arbitrary item or powerup dissapears when contacted by the player.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests whether an arbitrary item or powerup dissapears when contacted by the player.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test. 
 */
public class InteractableTests
{
    public string testScene = "OverworldDemoScene";

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
     * Summary: Function makes sure an item dissapears when player contacts it.
     * 
     */
    [UnityTest]
    public IEnumerator ItemDissapearTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        //find Item obj:
        Item itemClassInst = GameObject.FindObjectOfType<Item>();
        yield return null;

        //if couldn't find item:
        if( itemClassInst == null)
        {
            Assert.Inconclusive("Couldn't find item in test scene: " + testScene);
        }

        GameObject itemObj = itemClassInst.gameObject;

        //make sure player and Item on the same layer
        GameObject.FindGameObjectWithTag("Player").layer = itemObj.layer;
        yield return null;

        //ACT

        //set player to item location:
        GameObject.FindGameObjectWithTag("Player").transform.position = itemObj.transform.position;

        //let item dissapear:
        yield return new WaitForSeconds(0.5f);

        //ASSERT

        Debug.Log(itemObj.name + " is visible: " + itemObj.activeSelf);

        //make sure item has been changed to inactive:
        Assert.IsFalse(itemObj.activeSelf);
    }

    /*
     * Summary: Function makes sure a speed powerup dissapears when player contacts it.
     * 
     */
    [UnityTest]
    public IEnumerator PowerUpSpeedDissapearTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        //find power up obj:
        PowerUpSpeed powerUpClassInst = GameObject.FindObjectOfType<PowerUpSpeed>();
        yield return null;

        //if couldn't find powerup:
        if (powerUpClassInst == null)
        {
            Assert.Inconclusive("Couldn't find item in test scene: " + testScene);
        }

        GameObject powerUpObj = powerUpClassInst.gameObject;

        //make sure player and powerup on the same layer
        GameObject.FindGameObjectWithTag("Player").layer = powerUpObj.layer;
        yield return null;

        //ACT

        //set player to powerup location:
        GameObject.FindGameObjectWithTag("Player").transform.position = powerUpObj.transform.position;

        //let powerup dissapear:
        yield return new WaitForSeconds(0.5f);

        //ASSERT

        Debug.Log(powerUpObj.name + " is visible: " + powerUpObj.activeSelf);

        //make sure changed to inactive:
        Assert.IsFalse(powerUpObj.activeSelf);
    }

   
}