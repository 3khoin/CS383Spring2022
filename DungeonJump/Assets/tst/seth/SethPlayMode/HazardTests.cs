/*
 * Filename: HazardTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests ResetHazard, StaticDmgHazard, and destroying capabilities of Spawner class.
 * 
 */

//using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests ResetHazard, StaticDmgHazard, and destroying capabilities of Spawner class.
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
      * Summary: Function testing the damaging and redamaging capabilities of a static damage hazard.
      * 
      */
    [UnityTest]
    public IEnumerator StaticDmgHazardTest()
    {
        //throw new NotImplementedException();

        //Loads test scene
        SceneManager.LoadScene(testScene);

        //ARRANGE

        //have to wait longer than a frame for scene to load and reset hazard to spawn:
        yield return new WaitForSeconds(3f);

        //create a gameobj for damaging player
        GameObject dmgObj = new GameObject(name:"dmgObj", typeof(BoxCollider2D), typeof(StaticDmgHazard));
        dmgObj.GetComponent<BoxCollider2D>().edgeRadius = 0.1f;

        //find scene player:
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //set player + dmg obj to same layer:
        player.layer = dmgObj.layer;

        //ACT

        //teleport dmg obj on top of player:
        dmgObj.transform.position = player.transform.position;

        //let hazard damage:
        yield return new WaitForSeconds(0.1f);

        //ASSERT

        //store player hp:
        float initHitPlayerHP = PlayerManagerTmp.instance.GetPlayerHealth();

        //debug:
        print("Player hp after 1 hit: " + initHitPlayerHP);

        //pass if player health is less than full:
        Assert.Less(initHitPlayerHP, 1);

        //wait for longer than redamage delay:
        yield return new WaitForSeconds(dmgObj.GetComponent<StaticDmgHazard>().reDmgDelay + 0.1f);

        //pass if player health is less than before:
        Assert.Less(PlayerManagerTmp.instance.GetPlayerHealth(), initHitPlayerHP);

        yield return null;
    }
    

    /*
    * Summary: Function testing the destroying capabilities of the spawner.
    *           Currently inconclusive because unity testing of coroutines is difficult.
    */
    [UnityTest]
    public IEnumerator DestroyHazardTest()
    {
        //throw new NotImplementedException();

        Assert.Inconclusive("Can't test coroutines");

        //ARRANGE

        //have to wait longer than a frame for scene to load and reset hazard to spawn:
        //yield return new WaitForSeconds(3f);

        //create new spawner: (needs to be attached to a gameobj)
        GameObject spawnerObj = new GameObject(name: "Spawner");
        Spawner spawner = spawnerObj.AddComponent<Spawner>();

        //pass new obj as hazard:
        //spawner.hazard = new GameObject(name: "spawnedHazard");

        //create new test obj:
        GameObject rmObj = new GameObject(name: "removeObj");

        //add Test tag:
        rmObj.tag = testTag;

        //let obj be spawned:
        yield return new WaitForSeconds(0.1f);
       // yield return new WaitForSeconds(10f);

        //ACT

        Debug.Log("try removing: " + GameObject.FindGameObjectWithTag(testTag).name);

        //remove spawned test obj:
        //StartCoroutine(spawner.RemoveHazard(GameObject.FindGameObjectWithTag(testTag)));
        StartCoroutine(spawner.RemoveHazard(rmObj));

        //spawner.RemoveHazard(GameObject.FindGameObjectWithTag(testTag));

        //wait till longer than removal delay:
        yield return new WaitForSeconds(spawner.destroyDelay + 0.5f);

        //ASSERT

        //successfully removed gameobj if cant find test tag anymore:
        Assert.IsTrue(GameObject.FindGameObjectWithTag(testTag) == null);
    }
}