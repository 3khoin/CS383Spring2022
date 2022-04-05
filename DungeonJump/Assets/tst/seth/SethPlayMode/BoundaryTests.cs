/*
 * Filename: BoundaryTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests game boundaries by teleporting player outside of them 
 *          and verifying the player is put back within bounds. 
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests game boundaries by teleporting player outside of them 
 *          and verifying the player is put back within bounds.
 * 
 * Member Variables:
 * distanceOutsideBounds - float determining how far outside of bounds player should be teleported.
 * playerPos - Vector2 to store player's position.
 */
public class BoundaryTests 
{
    public float distanceOutsideBounds = 1;

    private Vector2 playerPos;

    /*
     * Summary: Loads test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {

        //testing starting scene: (scene selection arbitrary)
        SceneManager.LoadScene("OverworldSpawnArea"); 

        //cant do in setup for some reason: (bc has to be def'd above?)
        //GameObject playerObj = new GameObject("TestPlayer");
        //store intermediate value:
        //playerPos = playerObj.transform.position;

    }

    /*
     * Summary: Creates a new player object and teleports it outside of the right boundary. 
     *          Fails if player object isn't teleported back within game bounds.
     * 
     * Notes: 
     * A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
     * `yield return null;` to skip a frame.
     */
    [UnityTest]
    public IEnumerator RightBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        //wait to allow scene to load
        yield return new WaitForSeconds(1);

        //since error is thrown w/ script starts, try delaying its creation
        playerObj.AddComponent<CheckPlayerBounds>();

        //wait to allow attached script to load
        yield return new WaitForSeconds(1); 

        //Arrange
        //store rightmostX allowed:
        float rightMostX = playerObj.GetComponent<CheckPlayerBounds>().rightmostPnt.position.x;

        //act
        //store intermediate value out of range:
        playerPos.x = rightMostX + distanceOutsideBounds;

        //cant get and set at the same time
        //playerObj.GetComponent<Transform>().position.x = rightMostX + distanceOutsideBounds; 

        //change gameobj val to intermediate val:
        playerObj.transform.position = playerPos;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert
        //need to check player's actual position, not the prev saved val
        //player x pos should be rst to within boundary
        Assert.Less(playerObj.transform.position.x, rightMostX); 
    }

    /*
     * Summary: Creates a new player object and teleports it outside of the left boundary. 
     *          Fails if player object isn't teleported back within game bounds.
     */
    [UnityTest]
    public IEnumerator LeftBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); 

        playerObj.AddComponent<CheckPlayerBounds>(); 

        yield return new WaitForSeconds(1); 

        //Arrange
        //store rightmostX allowed:
        float leftMostX = playerObj.GetComponent<CheckPlayerBounds>().leftmostPnt.position.x;

        //act
        //store intermediate value out of range:
        playerPos.x = leftMostX - distanceOutsideBounds;

        //change gameobj val to intermediate val:
        playerObj.transform.position = playerPos;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert
        //need to check player's actual position, not the prev saved val
        Assert.Greater(playerObj.transform.position.x, leftMostX); 
    }

    /*
     * Summary: Creates a new player object and teleports it outside of the topmost boundary. 
     *          Fails if player object isn't teleported back within game bounds.
     */
    [UnityTest]
    public IEnumerator TopBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); 

        playerObj.AddComponent<CheckPlayerBounds>(); 

        yield return new WaitForSeconds(1); 

        //Arrange
        //store rightmostX allowed:
        float topMostY = playerObj.GetComponent<CheckPlayerBounds>().topmostPnt.position.y;

        //act
        //store intermediate value out of range:
        playerPos.x = topMostY + distanceOutsideBounds;

        //change gameobj val to intermediate val:
        playerObj.transform.position = playerPos;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert
        //need to check player's actual position, not the prev saved val
        Assert.Less(playerObj.transform.position.y, topMostY); 
    }

    /*
     * Summary: Creates a new player object and teleports it outside of the bottom boundary. 
     *          Fails if player object isn't teleported back within game bounds.
     */
    [UnityTest]
    public IEnumerator BotBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); 

        playerObj.AddComponent<CheckPlayerBounds>(); 

        yield return new WaitForSeconds(1); 

        //Arrange
        //store rightmostX allowed:
        float botMostY = playerObj.GetComponent<CheckPlayerBounds>().botmostPnt.position.y;

        //act
        //store intermediate value out of range:
        playerPos.y = botMostY - distanceOutsideBounds;

        //change gameobj val to intermediate val:
        playerObj.transform.position = playerPos;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert
        //need to check player's actual position, not the prev saved val
        Assert.Greater(playerObj.transform.position.y, botMostY); 
    }

    /*
     * Summary: Unloads the loaded test scene.
     */
    /*
    [TearDown]
    public void Teardown()
    {
        //destroy test player: (after 5 secs)
        //GameObject.Destroy(gameObject, 5); 

        //should unload scene?
        SceneManager.UnloadSceneAsync("Overworld Spawn Area");
    }
    */
}
