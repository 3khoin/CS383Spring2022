/*
* Filename: ExitGateTests.cs
* Developer: Chadwick Goodall
* Purpose: Testing exit gates
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ExitGateTests
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
    * Summary: Teleport the player to an exit gate and check if the scene changes
    */
    [UnityTest]
    public IEnumerator ExitGate()
    {
        // Arrange
        // find the player and exit gate as well as the current scene name
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject exitGate = GameObject.FindGameObjectWithTag("Exit");
        string scene = SceneManager.GetActiveScene().name;

        // Act
        // move player to the exit gate
        player.transform.position = exitGate.transform.position;
        yield return new WaitForSeconds(.2f);

        // Assert
        // check that the current scene is no longer the same as the previous scene
        Assert.AreNotSame(scene,SceneManager.GetActiveScene().name);
        yield return null;
    }
}
