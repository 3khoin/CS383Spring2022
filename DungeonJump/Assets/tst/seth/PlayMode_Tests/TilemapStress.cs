using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps; //for tilemap usage

//TAKES 3 MINUTES TO FREEZE UNITY (USE WITH CAUTION)
public class TilemapStress : MonoBehaviour
{
    [SetUp]
    public void setup()
    {
        SceneManager.LoadScene("StressTest");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TilemapStressTest()
    {
        //arrange
        GameObject tilemapObj = new GameObject("Tilemap Obj", typeof(Tilemap), typeof(TilemapCollider2D), 
                                                typeof(Rigidbody2D), typeof(CompositeCollider2D));
        int i = 1;

        //yield return new WaitForSeconds(1); //give user a second to navigate to the 

        //act 
        while( i < int.MaxValue )
        {
            Instantiate(tilemapObj);

            print(i + " tilemaps instantiated");

            i++;

            yield return null;
        }

        yield return null;

        //assert
        Assert.True(false); //failed if it made it to this point

    }

    [TearDown]
    public void teardown()
    {
        SceneManager.UnloadSceneAsync("StressTest");
    }
}
