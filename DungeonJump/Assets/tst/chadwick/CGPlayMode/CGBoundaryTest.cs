using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CGBoundaryTest
{
    [SetUp]
    public void Setup(){
        SceneManager.LoadScene(2);
        // objects created in setup are destroyed upon exit of function
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TopBoundTest()
    {
        // arrange
        GameObject topPnt = GameObject.FindGameObjectWithTag("top");
        Vector2 topPntPos = topPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;


        // act
        playerPos.y = topPntPos.y + 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Less(player.transform.position.y, topPntPos.y);
    }

    [UnityTest]
    public IEnumerator BotBoundTest()
    {
        // arrange
        GameObject botPnt = GameObject.FindGameObjectWithTag("bot");
        Vector2 botPntPos = botPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;

        // act
        playerPos.y = botPntPos.y - 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Greater(player.transform.position.y, botPntPos.y);
    }

    [UnityTest]
    public IEnumerator LeftBoundTest()
    {
        // arrange
        GameObject leftPnt = GameObject.FindGameObjectWithTag("left");
        Vector2 leftPntPos = leftPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;

        // act
        playerPos.y = leftPntPos.x - 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Greater(player.transform.position.x, leftPntPos.x);
    }

    [UnityTest]
    public IEnumerator RightBoundTest()
    {
        // arrange
        GameObject rightPnt = GameObject.FindGameObjectWithTag("right");
        Vector2 rightPntPos = rightPnt.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.GetComponent<Transform>().position;

        // act
        playerPos.x = rightPntPos.x + 1;
        player.transform.position = playerPos;
        yield return null;
        
        // assert
        Assert.Less(player.transform.position.x, rightPntPos.x);
    }

    [TearDown]
    public void Teardown(){

    }
}
