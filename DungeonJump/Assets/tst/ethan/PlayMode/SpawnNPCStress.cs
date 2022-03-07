using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// record 16070 before freezing

public class SpawnNPCStress
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("StressTest");
    }
    // this test will see how many NPC spawns it takes to break Unity
    [UnityTest]
    public IEnumerator SpawnTest()
    {
        // Use the Assert class to test conditions
        var NPC = GameObject.FindGameObjectWithTag("FriendlyNPC"); // get NPC for spawning
        yield return new WaitForSeconds(1); //wait to allow scene to load
        int count = 0;

        while (count < int.MaxValue)
        {
            GameObject.Instantiate(NPC);
            count++;
            Debug.Log(count + "Instances Spawned");
            yield return null;
        }
        yield return null;
        
        Assert.True(false); // test failed to end Unity
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("StressTest");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}
