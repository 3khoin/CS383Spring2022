/*
 * Filename: CamTests.cs 
 * Developer: Seth Cram
 * Purpose: File tests whether camera follows player when their position changes.
 * 
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/*
 * Summary: Class tests whether camera follows player when their position changes.
 * 
 * Member Variables:
 * testScene - string name of scene being used to test. 
 * precision - Float that allow camera to be near instead of exactly on top of player.  
 */
public class CamTests
{
    public string testScene = "OverworldDemoScene";

    public float precision = 1;

    /*
     * Summary: Loads test scene.
     *  
     */
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(testScene);
    }

    /*
     * Summary: Function teleports player to anywhere within bounds and checks if camera follows.
     * 
     */
    [UnityTest]
    public IEnumerator FollowTest()
    {
        //ARRANGE

        //have to wait longer than a frame for scene to load:
        yield return new WaitForSeconds(0.5f);

        //store player and their bounds script:
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CheckPlayerBounds boundsScript = player.GetComponent<CheckPlayerBounds>();

        //store main camera:
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");

        //ACT

        //set player to random location within bounds: (change by 1 so not teleported back to spawn)
        player.transform.position = new Vector3( 
            Random.Range(boundsScript.leftmostPnt.position.x + 1, boundsScript.rightmostPnt.position.x - 1), 
            Random.Range(boundsScript.botmostPnt.position.y + 1, boundsScript.topmostPnt.position.y - 1), 0 );

        //let camera catch up:
        yield return new WaitForSeconds(4f);

        //ASSERT

        Debug.Log("Camera location: " + cam.transform.position);
        Debug.Log("Player location: " + player.transform.position);

        //make sure cam has been changed to player's coords within given precision:
        Assert.IsTrue(player.transform.position.x - precision <= cam.transform.position.x &&
                cam.transform.position.x <= player.transform.position.x + precision);
        Assert.IsTrue(player .transform.position.y - precision <= cam.transform.position.y &&
                cam.transform.position.y <= player.transform.position.x + precision);
    }

}