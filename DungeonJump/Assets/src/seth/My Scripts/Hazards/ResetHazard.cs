/*
 * Filename: ResetHazard.cs 
 * Developer: Seth Cram
 * Purpose: File resets the player if they're hit by the GameObject this script is attached to. 
 * 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: Class resets the player if they're hit by the GameObject this script is attached to.
 * 
 */
public class ResetHazard : Hazard
{
    /*
     * Summary: Reloads the scene if the GameObject this script is attached to hits the player.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    override public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if( collision.gameObject.tag == "Player")
        {
            print("Scene should be reset");

            //reset scene:
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
