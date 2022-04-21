/*
* Filename: BouncePlatformTests.cs
* Developer: Chadwick Goodall
* Purpose: Testing bounce platforms
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BouncePlatformTests
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
    * Summary: Move the player onto a bounce platform and check if it launches the player
    */
    [UnityTest]
    public IEnumerator BouncePlatform()
    {
        // Arrange
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject bounce = GameObject.FindGameObjectsWithTag("BouncePlatform")[0];
        yield return null;

        // Act
        // move the player to the bounce platform and let some time pass
        // the player should be launched and their y position should be greater than it was initially
        player.transform.position =  bounce.transform.position;
        Vector2 initPosition = player.transform.position;
        yield return new WaitForSeconds(.2f);
        Vector2 newPosition =  player.transform.position;

        // Assert
        Assert.Greater(newPosition.y, initPosition.y);
        yield return null;
    }
}
