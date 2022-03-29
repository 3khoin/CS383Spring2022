/*
 * Filename: Entryway.cs 
 * Developer: Seth Cram 
 * Purpose: File that inverts the entryway when player is within range and presses E. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class that inverts the entryway when player is within range and presses E.
 * 
 * Member Variables:
 * openDoor - Gameobject of an open door.
 * closedDoor - Gameobject of a closed door.
 * interactSound - AudioSource that should be played when door is inverted.
 * open - Boolean to keep track of whether door is open or not.
 * entrywayInteractable - Boolean to keep track of whether dorr can be interacted with or not.
 */
public class Entryway : MonoBehaviour
{
    public GameObject openDoor; //public AnimationClip openAnim;
    public GameObject closedDoor; //public AnimationClip closeAnim;
    public AudioSource interactSound;

    private bool open = false;
    private bool entrywayInteractable = false;

    /*
     * Summary: Every frame invert the entryway if it's interactable and player presses E.
     * 
     */
    void Update()
    {
        if( entrywayInteractable )
        {
            if (Input.GetKeyDown(KeyCode.E)) //player presses "E" on keyboard
            {
                //change entryway state:
                InvertEntryway();
            }
        }
    }

    /*
     * Summary: Make entryway interactable when player enters trigger.
     * 
     * Parameters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //player is in contact w/ door
        {
            entrywayInteractable = true;
        }
    }

    /*
     * Summary: Make entryway uninteratable when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //player is in contact w/ door
        {
            entrywayInteractable = false;
        }
    }

    /*
     * Summary: Open or close the entryway depending upon its current state.
     * 
     */
    public void InvertEntryway() //should be called by player w/ interact w/ entryway
    {
        if( open )
        {
            //close entryway
            openDoor.SetActive(false); //deactivate open door
            closedDoor.SetActive(true); //activate closed door
            open = false;
        }
        else
        {
            //open entryway
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
            open = true;
        }
    }
}
