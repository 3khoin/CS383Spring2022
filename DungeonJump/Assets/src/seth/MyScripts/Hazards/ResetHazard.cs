/*
 * Filename: ResetHazard.cs 
 * Developer: Seth Cram
 * Purpose: File resets the player and camera to their spawn point if they're hit by the GameObject 
 *          this script is attached to. 
 * 
 */

using UnityEngine;
//using UnityEngine.SceneManagement;

/*
 * Summary: Class that resets the player and camera 
 *          if they're hit by the GameObject this script is attached to.
 * 
 */
public class ResetHazard : Hazard
{
    /*
     * Summary: Resets the gameobjects tagged "Player" and "MainCamera" if the GameObject this 
     *          script is attached to hits the player.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    override public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if( collision.gameObject.tag == "Player")
        {
            print("Player should be reset");

            //reset scene:
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //store spawn point position:
            Vector3 spawnPnt = GameObject.FindGameObjectWithTag("Spawn").transform.position;

            //reset player to spawn point:
            collision.gameObject.transform.position = spawnPnt;

            //reset main camera to spawn point:
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = spawnPnt;
        }
    }
}
