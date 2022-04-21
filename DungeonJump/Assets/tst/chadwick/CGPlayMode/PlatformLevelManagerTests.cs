/*
* Filename: PlatformLevelManagerTests.cs
* Developer: Chadwick Goodall
* Purpose: Testing the platform level manager
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlatformLevelManagerTests
{


    /*
    * Summary: Sets up the scene for testing
    */
    [SetUp]
    public void Setup(){
        SceneManager.LoadScene("CoconutCave");
        // objects created in setup are destroyed upon exit of function
    }

    /*
    * Summary: Tests exiting the top bound
    */
    [UnityTest]
    public IEnumerator TopBoundTest()
    {
        // arrange
        GameObject topPnt = GameObject.FindGameObjectWithTag("top");
        Vector2 topPntPos = topPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;
        player.transform.position = new Vector3(0,0,0);
        yield return null;


        // act
        playerPos.y = topPntPos.y + 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Less(player.transform.position.y, topPntPos.y);
        
    }


    /*
    * Summary: Tests exiting the bottom bound
    */
    [UnityTest]
    public IEnumerator BotBoundTest()
    {
        // arrange
        GameObject botPnt = GameObject.FindGameObjectWithTag("bot");
        Vector2 botPntPos = botPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;
        player.transform.position = new Vector3(0,0,0);
        yield return null;

        // act
        playerPos.y = botPntPos.y - 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Greater(player.transform.position.y, botPntPos.y);
    }


    /*
    * Summary: Tests exiting the left bound
    */
    [UnityTest]
    public IEnumerator LeftBoundTest()
    {
        // arrange
        GameObject leftPnt = GameObject.FindGameObjectWithTag("left");
        Vector2 leftPntPos = leftPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;
        player.transform.position = new Vector3(0,0,0);
        yield return null;

        // act
        playerPos.x = leftPntPos.x - 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Greater(player.transform.position.x, leftPntPos.x);
    }


    /*
    * Summary: Tests exiting the right bound
    */
    [UnityTest]
    public IEnumerator RightBoundTest()
    {
        // arrange
        GameObject rightPnt = GameObject.FindGameObjectWithTag("right");
        Vector2 rightPntPos = rightPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;
        player.transform.position = new Vector3(0,0,0);
        yield return null;

        // act
        playerPos.x = rightPntPos.x + 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Less(player.transform.position.x, rightPntPos.x);
    }


    /*
    * Summary: Tests level initialization
    */
    [UnityTest]
    public IEnumerator LevelInitTest()
    {
        // Arrange
        // get the player, spawn, camera and different points
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject topPnt = GameObject.FindGameObjectWithTag("top");
        GameObject botPnt = GameObject.FindGameObjectWithTag("bot");
        GameObject leftPnt = GameObject.FindGameObjectWithTag("left");
        GameObject rightPnt = GameObject.FindGameObjectWithTag("right");
        yield return null;

        // Act
        // allow some time to pass for the level manager to initialize
        yield return new WaitForSeconds(.5f);

        // Assert
        Assert.IsNotNull(player.GetComponent<AudioListener>());
        // it is sufficient to check just the x positions
        Assert.AreEqual(player.transform.position.x, spawn.transform.position.x);
        Assert.AreEqual(player.transform.position.x, cam.transform.position.x);
        Assert.IsNotNull(spawn);
        Assert.IsNotNull(topPnt);
        Assert.IsNotNull(botPnt);
        Assert.IsNotNull(leftPnt);
        Assert.IsNotNull(rightPnt);
        yield return null;
    }


    /*
    * Summary: Tests checking player health and resetting the player
    */
    [UnityTest]
    public IEnumerator CheckHealth()
    {
        // Arrange
        // find the player and make sure they're at spawn
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        player.transform.position =  spawn.transform.position;
        yield return null;

        // Act
        // move the player from spawn and update health to be zero
        player.transform.position += new Vector3 (10,0,0);
        PlayerManagerTmp.instance.UpdatePlayerHealth(-1f);
        // wait for some time to allow the player manager to reset the player
        yield return new WaitForSeconds(.1f);


        // Assert
        // player should now be back at spawn with updated health, score, and position
        Assert.AreEqual(player.transform.position.x, spawn.transform.position.x);
        Assert.LessOrEqual(PlayerManagerTmp.instance.GetPlayerScore(), 0);
        Assert.True(PlayerManagerTmp.instance.GetPlayerHealth() == 1);
        yield return null;
    }

    [TearDown]
    public void Teardown(){

    }
}
