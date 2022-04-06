/*
 * Filename: HazardTests.cs 
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
 * spawnOffset - Vector3 distance from spawn point that test takes place.
 */
public class HazardTests: MonoBehaviour
{
    public string testScene = "OverworldSpawnArea";

    public Vector3 spawnOffset = new Vector3(5, 5, 0);

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
     * Summary: Function testing the reset capabilities of a reset hazard.
     * 
     */
    [UnityTest]
    public IEnumerator ResetHazardTest()
    {
        //ARRANGE

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
  * Summary: Function testing the reset capabilities of a reset hazard.
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
}