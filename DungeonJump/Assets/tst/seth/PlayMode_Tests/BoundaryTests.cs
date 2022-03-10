using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BoundaryTests //: MonoBehaviour //need monobehavior for 'GameObject' type
{
    public float distanceOutsideBounds;

    private Vector2 playerPos;

    [SetUp]
    public void Setup()
    {
        distanceOutsideBounds = 1;

        //testing starting scene:
        SceneManager.LoadScene(6); //needed for boundary pnts?

        //cant do in setup for some reason: (bc has to be def'd above?)
        //GameObject playerObj = new GameObject("TestPlayer");
        //store intermediate value:
        //playerPos = playerObj.transform.position;

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator RightBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); //wait to allow scene to load

        playerObj.AddComponent<CheckPlayerBounds>(); //since error is thrown w/ script starts, try delaying its creation

        yield return new WaitForSeconds(1); //wait to allow attached script to load

        //Arrange
        //store rightmostX allowed:
        float rightMostX = playerObj.GetComponent<CheckPlayerBounds>().rightmostPnt.position.x;

        //act
        //store intermediate value out of range:
        playerPos.x = rightMostX + distanceOutsideBounds;

        //playerObj.GetComponent<Transform>().position.x = rightMostX + distanceOutsideBounds; //cant get and set at the same time

        //change gameobj val to intermediate val:
        playerObj.transform.position = playerPos;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        //assert
        //need to check player's actual position, not the prev saved val
        Assert.Less(playerObj.transform.position.x, rightMostX); //player x pos should be rst to within boundary
    }

    [UnityTest]
    public IEnumerator LeftBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); //wait to allow scene to load

        playerObj.AddComponent<CheckPlayerBounds>(); //since error is thrown w/ script starts, try delaying its creation

        yield return new WaitForSeconds(1); //wait to allow attached script to load

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
        Assert.Greater(playerObj.transform.position.x, leftMostX); //player x pos should be rst to within boundary
    }

    [UnityTest]
    public IEnumerator TopBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); //wait to allow scene to load

        playerObj.AddComponent<CheckPlayerBounds>(); //since error is thrown w/ script starts, try delaying its creation

        yield return new WaitForSeconds(1); //wait to allow attached script to load

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
        Assert.Less(playerObj.transform.position.y, topMostY); //player x pos should be rst to within boundary
    }

    [UnityTest]
    public IEnumerator BotBoundaryTest()
    {
        //if not inherting from monobehavior, can create new gameobjs:
        GameObject playerObj = new GameObject("TestPlayer");

        //store intermediate value:
        playerPos = playerObj.transform.position;

        yield return new WaitForSeconds(1); //wait to allow scene to load

        playerObj.AddComponent<CheckPlayerBounds>(); //since error is thrown w/ script starts, try delaying its creation

        yield return new WaitForSeconds(1); //wait to allow attached script to load

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

        //yield return new WaitForSeconds(1); //wait before checking

        //assert
        //need to check player's actual position, not the prev saved val
        Assert.Greater(playerObj.transform.position.y, botMostY); //player x pos should be rst to within boundary
    }

    [TearDown]
    public void Teardown()
    {
        //destroy test player: (after 5 secs)
        //GameObject.Destroy(gameObject, 5); 

        //should unload scene?
        //SceneManager.UnloadSceneAsync(0);
    }
}
