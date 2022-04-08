/*
 * Filename: EntrywayTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests Opening and closing capabilities of entryways.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests Opening and closing capabilities of entryways.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test.   
 */
public class EntrywayTests: MonoBehaviour
{
    public string testScene = "OverworldSpawnArea";

    /*
     * Summary: Load test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(testScene);
    }

    /*
     * Summary: Function testing whether the door's state will be inverted.
     *          Starts with closed door active and open door inactive.
     * 
     */
    [UnityTest]
    public IEnumerator OpenDoorTest()
    {
        //ARRANGE

        //wait for scene to load:
        yield return new WaitForSeconds(2f);

        //create entryway gameobj:
        GameObject entryObj = new GameObject(name: "entryway");
        Entryway entryway = entryObj.AddComponent<Entryway>();

        //entryway start method also called here

        //fill out door fields

        entryway.closedDoor = new GameObject(name: "closedDoor");

        //start w/ open door model inactive:
        entryway.openDoor = new GameObject(name: "openDoor");
        entryway.openDoor.SetActive(false);

        Debug.Log("closed door init state: " + entryway.closedDoor.activeSelf);

        //ACT
        
        //invert the entryway:
        entryway.InvertEntryway();

        yield return new WaitForSeconds(0.1f);

        Debug.Log("closed door final state: " + entryway.closedDoor.activeSelf);

        //ASSERT

        //closed door should now be inactive:
        Assert.IsFalse(entryway.closedDoor.activeSelf);

        //open door should now be active:
        Assert.IsTrue(entryway.openDoor.activeSelf);

        yield return null;
    }

    /*
     * Summary: Function testing whether the door's state will be inverted.
     *          Starts with closed door inactive and open door active.
     * 
     */
    [UnityTest]
    public IEnumerator CloseDoorTest()
    {
        //ARRANGE

        //wait for scene to load:
        yield return new WaitForSeconds(2f);

        //create entryway gameobj:
        GameObject entryObj = new GameObject(name: "entryway");
        Entryway entryway = entryObj.AddComponent<Entryway>();

        //fill out door fields

        //start w/ closed door model inactive:
        entryway.closedDoor = new GameObject(name: "closedDoor");
        entryway.closedDoor.SetActive(false);


        entryway.openDoor = new GameObject(name: "openDoor");

        Debug.Log("closed door init state: " + entryway.closedDoor.activeSelf);

        //start called here
        yield return null;

        //ACT

        //invert the entryway:
        entryway.InvertEntryway();

        yield return new WaitForSeconds(0.1f);

        Debug.Log("closed door final state: " + entryway.closedDoor.activeSelf);

        //ASSERT

        //closed door should now be active:
        Assert.IsTrue(entryway.closedDoor.activeSelf);

        //open door should now be inactive:
        Assert.IsFalse(entryway.openDoor.activeSelf);

        yield return null;
    }

 
}