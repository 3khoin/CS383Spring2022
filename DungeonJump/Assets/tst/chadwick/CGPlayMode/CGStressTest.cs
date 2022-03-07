using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// logged 10545 instances before freezing
public class CGStressTest
{
    [SetUp]
    public void Setup()
    {   // load dummy scene
        SceneManager.LoadScene("CGStressTest");
    }

    // test should effectively spawn multiple player GameObjects into a dummy platformer level until Unity breaks
    [UnityTest]
    public IEnumerator CGStressTestPlayer()
    {   
        // create player object to instantiate
        GameObject playerObj = new GameObject("playerObj", typeof(BoxCollider2D),
                                            typeof(Rigidbody2D), typeof(SpriteRenderer));
        int i = 0; 
        // repeatedly spawn playerObj
        while (i < int.MaxValue){
            GameObject.Instantiate(playerObj); // make a new instance, increment the counter i, log the amount of instances
            i++;
            Debug.Log(i + " instances of playerObj created.");
            yield return null;
        }
        yield return null; // should freeze before ever reaching here
        Assert.True(false); // if it does reach here then something went wrong with the test
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("CGStressTest");
    }
}


