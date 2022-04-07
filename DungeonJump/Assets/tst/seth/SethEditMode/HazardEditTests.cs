/*
 * Filename: HazardEditTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests the spawning capabilities of the Spawner class.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/*
 * Summary: Class tests the spawning capabilities of the Spawner class.
 * 
 * Member Variables:
 * testTag - string of the tag solely used for testing.
 */
public class HazardEditTests: MonoBehaviour
{

    public string testTag = "Test";

    /*
    * Summary: Function testing the spawning capabilities of the spawner.
    * 
    */
    [UnityTest]
    public IEnumerator SpawnHazardTest()
    {
        //ARRANGE

        //create new spawner: (needs to be attached to a gameobj)
        GameObject spawnerObj = new GameObject(name:"Spawner");
        Spawner spawner = spawnerObj.AddComponent<Spawner>();

        //pass new obj as hazard:
        spawner.hazard = new GameObject(name:"spawnedHazard");

        //add Test tag:
        spawner.hazard.tag = testTag;

        //ACT

        //spawn passed in hazard:
        spawner.SpawnHazard();

        //ASSERT

        //true if can find 2 gameobj with test tag on it: (1 created for filling field, other w/ spawned)
        Assert.Greater(GameObject.FindGameObjectsWithTag(testTag).Length, 1);

        //BREAKDOWN
        //don't destroy in edit mode tests

        yield return null;
    }
}