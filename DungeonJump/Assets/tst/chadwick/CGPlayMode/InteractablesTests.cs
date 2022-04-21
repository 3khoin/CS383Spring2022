/*
* Filename: InteractablesTests.cs
* Developer: Chadwick Goodall
* Purpose: Testing interactable objects (powerups, coins, quest items)
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class InteractablesTests
{
    public static GameObject player;
    public static GameObject coinObj;
    public static GameObject questItemObj;
    public static GameObject spawn;

    /*
    * Summary: Sets up the scene for testing
    */
    [SetUp]
    public void Setup(){
        SceneManager.LoadScene("CoconutCave");
    }

    /*
    * Summary: Tests the activation of a coin
    */
    [UnityTest]
    public IEnumerator InteractablesCoin()
    {
        // Arrange
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        float initScore = PlayerManagerTmp.instance.GetPlayerScore();
        coinObj = GameObject.FindGameObjectsWithTag("Coin")[0];
        player.transform.position =  spawn.transform.position;
        yield return null;

        // Act
        // make the player collect the coin
        player.transform.position =  coinObj.transform.position;
        yield return new WaitForSeconds(.1f);

        // Assert
        // check that the player's score has increased
        Assert.Greater(PlayerManagerTmp.instance.GetPlayerScore(), initScore);
        yield return null;
    }


    /*
    * Summary: Tests the activation of a quest item
    */
    [UnityTest]
    public IEnumerator InteractablesQuestItem()
    {
        // Arrange
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        questItemObj = GameObject.FindGameObjectWithTag("QuestItem");
        string questItemName = questItemObj.name;
        player.transform.position =  spawn.transform.position;
        yield return null;

        // Act
        // move player to the quest item
        player.transform.position = questItemObj.transform.position;
        yield return new WaitForSeconds(.1f);

        // Assert
        // check to make sure the quest item has been collected
        Assert.True(PlayerManagerTmp.instance.QuestItemIsCollected(questItemName));
        yield return null;
    }
}
