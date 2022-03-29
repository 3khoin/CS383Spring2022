/*
 * Filename: TilemapStress.cs 
 * Developer: Seth Cram
 * Purpose: File repeatedly spawns tilemaps every frame until the max int is reached.
 *          Spawned within a specified StressTest scene. 
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps; 

/*
 * Summary: Class repeatedly spawns tilemaps every frame until the max int is reached.
 *          Spawned within a specified StressTest scene.
 * 
 * Notes:
 * TAKES 3 MINUTES TO FREEZE UNITY (USE WITH CAUTION)
 * 
 */
public class TilemapStress : MonoBehaviour
{
    /*
     * Summary: Loads the StressTest scene.
     * 
     */
    [SetUp]
    public void setup()
    {
        SceneManager.LoadScene("StressTest");
    }

    /*
     * Summary: Repeatedly spawns tilemaps every frame until the max int is reached.  
     * 
     */
    [UnityTest]
    public IEnumerator TilemapStressTest()
    {
        //arrange
        GameObject tilemapObj = new GameObject("Tilemap Obj", typeof(Tilemap), typeof(TilemapCollider2D), 
                                                typeof(Rigidbody2D), typeof(CompositeCollider2D));
        int i = 1;  

        //act 
        while ( i < int.MaxValue )
        {
            Instantiate(tilemapObj);

            print(i + " tilemaps instantiated");

            i++;

            yield return null;
        }

        yield return null;

        //assert
        //failed if it made it to this point
        Assert.True(false); 

    }
    
    /*
     * Summary: unloads StressTest scene.
     * 
     */
    [TearDown]
    public void teardown()
    {
        SceneManager.UnloadSceneAsync("StressTest");
    }
}
