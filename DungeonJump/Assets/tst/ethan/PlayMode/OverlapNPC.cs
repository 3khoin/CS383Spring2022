using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;



public class OverlapNPC
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Overworld Demo Scene");
    }
    // this test will check to see if any NPCs have colliders that intersect
    [UnityTest]
    public IEnumerator OverlapTest()
    {
        // Use the Assert class to test conditions
        var NPC = GameObject.FindGameObjectsWithTag("FriendlyNPC"); // get all NPCs via tag
        
        yield return new WaitForSeconds(1); //wait to allow scene to load

        int count = NPC.Length; // see how many NPCs there are
        if(count < 2) Assert.True(true); // if 0 or 1 npc, no overlap can occur
        else
        {
            // nested for loop to cycle through all NPCs
            for(int i = 0; i < count-1; i++) { // first NPC to compare
                for(int j = i+1; j < count; j++) { // second NPC to compare
                    var npc1 = NPC[i].GetComponent<Collider2D>().bounds; // bounds of first NPC
                    var npc2 = NPC[j].GetComponent<Collider2D>().bounds; // bounds of second NPC
                    if (npc1.Intersects(npc2)) Assert.IsTrue(false); // sees if bounds intersect
                }
            }
            Assert.IsTrue(true); // no intersects
        }
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("Overworld Demo Scene");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}