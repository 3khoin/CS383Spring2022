/*
 * Filename: HazardTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests ResetHazard, StaticDmgHazard, and spawning capabilities of Spawner class.
 * 
 */

using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests ResetHazard, StaticDmgHazard, and spawning capabilities of Spawner class.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test.   
 * spawnOffset - Vector3 distance from spawn point that test takes place.
 * testTag - string of the tag solely used for testing.
 */
public class HazardTests: MonoBehaviour
{
    public string testScene = "OverworldSpawnArea";

    public Vector3 spawnOffset = new Vector3(5, 5, 0);

    public string testTag = "Test";

    /*
     * Summary: .
     *  
     */
    [SetUp]
    public void Setup()
    {
        
    }

    /*
     * Summary: Function testing the reset capabilities of a reset hazard.
     * 
     */
    [UnityTest]
    public IEnumerator ResetHazardTest()
    {
        //ARRANGE

        //Loads test scene
        SceneManager.LoadScene(testScene);

        //have to wait longer than a frame for scene to load and reset hazard to spawn:
        yield return new WaitForSeconds(3f);

        //create gameobj w/ reset hazard script and collider attached
        //cant add collider bc not sprite?
        //GameObject newObj = new GameObject(name: "ResetHazard", typeof(BoxCollider2D));
        //newObj.AddComponent<ResetHazard>();

        //instantiate gameobj w/ reset hazard script and collider attached:
        //GameObject rstHazardObj = Instantiate(newObj);

        yield return null;

        //store player:
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //store reset hazard:
        GameObject rstHazardObj = GameObject.FindObjectOfType<ResetHazard>().gameObject;

        //make sure player on same layer as hazard:
        player.layer = rstHazardObj.layer;

        //store spawnpoint:
        Transform spawnTransform = GameObject.FindGameObjectWithTag("Spawn").transform;

        //ACT

        //if spawn offset not set:
        if( spawnOffset == new Vector3(0, 0, 0))
        {
            //cant tell if player reset:
            Assert.Inconclusive("Can't test since offset from spawn point is zero.");
        }

        //set player to outside of the spawnPoint:
        player.transform.position = spawnTransform.position + spawnOffset;

        //set hazard to player:
        rstHazardObj.transform.position = player.transform.position;

        //let player be reset:
        yield return new WaitForSeconds(0.5f);

        //ASSERT

        //if player is reset to spawn point, test passed:
        Assert.AreEqual( spawnTransform.position, player.transform.position);
    }

        /*
      * Summary: Function testing the damaging capabilities of a static damage hazard.
      * 
      */
    /*
    [UnityTest]
    public IEnumerator StaticDmgHazardTest()
    {
        //ARRANGE

        //ACT

        //ASSERT
    }
    */

    /*
    * Summary: Function testing the destroying capabilities of the spawner.
    * 
    */
    [UnityTest]
    public IEnumerator DestroyHazardTest()
    {
        throw new NotImplementedException();

        //ARRANGE

        //have to wait longer than a frame for scene to load and reset hazard to spawn:
        //yield return new WaitForSeconds(3f);

        //create new spawner: (needs to be attached to a gameobj)
        GameObject spawnerObj = new GameObject(name: "Spawner");
        Spawner spawner = spawnerObj.AddComponent<Spawner>();

        //pass new obj as hazard:
        spawner.hazard = new GameObject(name: "spawnedHazard");

        //create new test obj:
        GameObject rmObj = new GameObject(name: "removeObj");

        //add Test tag:
        rmObj.tag = testTag;

        //let obj be spawned:
        //yield return new WaitForSeconds(0.1f);
       // yield return new WaitForSeconds(10f);

        //ACT

        Debug.Log("try removing: " + GameObject.FindGameObjectWithTag(testTag).name);

        //remove spawned test obj:
        spawner.RemoveHazard(GameObject.FindGameObjectWithTag(testTag));

        //wait till longer than removal delay:
        yield return new WaitForSeconds(spawner.destroyDelay + 0.5f + 10f);

        //ASSERT

        //removed gameobj if cant find test tag anymore:
        Assert.IsFalse(GameObject.FindGameObjectWithTag(testTag));
    }
}