/*
 * Filename: Hazard.cs 
 * Developer: Seth Cram 
 * Purpose: File used to document when player enters and exits a trigger. 
 * 
 */

using UnityEngine;

/*
 * Summary: Superclass used to document when player enters and exits a trigger.
 * 
 * Member Variables:
 * //hazardSound - AudioSource that should be played by sub-classes when something is inflicted upon player.
 */
public class Hazard : MonoBehaviour
{
    //public AudioSource hazardSound;

    /*
     * Summary: Displays message on console when player enters trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            print("hazard triggered by player entering");    
    }

    /*
     * Summary: Displays message on console when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    virtual public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            print("hazard triggered by player exiting");
    }

}
