using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

// Ethan Hinkle NPC boundary test for if NPCs are on a valid tile

public class OutsideBoundsNPC
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Overworld Demo Scene");
    }
    // this test will check to see if any NPCs are outside the world bounds
    [UnityTest]
    public IEnumerator BoundsTest()
    {
        // Use the Assert class to test conditions
        var NPC = GameObject.FindGameObjectsWithTag("FriendlyNPC"); // get all NPCs via tag
        var Tile = GameObject.FindObjectOfType<Tilemap>(); // gets tilemap
        yield return new WaitForSeconds(1); //wait to allow scene to load

        int count = NPC.Length; // see how many NPCs there are
        for (int i = 0; i < count; i++){
            Vector3 pos = NPC[i].transform.position; // get NPC position
            if (Tile.GetCellCenterWorld(Tile.WorldToCell(pos)) == null) Assert.IsTrue(false); // if tile is null then outside bounds
        }
        Assert.IsTrue(true); // if no tiles were false
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("Overworld Demo Scene");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}