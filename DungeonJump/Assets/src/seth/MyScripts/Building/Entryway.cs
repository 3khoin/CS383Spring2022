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
 * //interactSound - AudioSource that should be played when door is inverted.
 * open - Boolean to keep track of whether door is open or not.
 * entrywayInteractable - Boolean to keep track of whether dorr can be interacted with or not.
 */
public class Entryway : MonoBehaviour
{
    public GameObject openDoor; 
    public GameObject closedDoor; 

    private bool open = false;
    private bool entrywayInteractable = false;

    /*
     * summary: Makes sure open boolean is properly set.
     * 
     */
    private void Start()
    {
        //debug: Debug.Log("Start called");

        //if door already open or not closed:
        if ( openDoor != null && openDoor.activeSelf || !closedDoor.activeSelf)
            //set variable as such
            open = true;
    }

    /*
     * Summary: Every frame invert the entryway if it's interactable and player presses E.
     * 
     */
    void Update()
    {
        if( entrywayInteractable )
        {
            //player presses "E" on keyboard
            if (Input.GetKeyDown(KeyCode.E)) 
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
        // player is in contact w/ area around door
        if (collision.gameObject.tag == "Player") 
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
        //player is in contact w/ area around door door 
        if (collision.gameObject.tag == "Player") 
        {
            entrywayInteractable = false;
        }
    }

    /*
     * Summary: Open or close the entryway depending upon its current state and play sound FX.
     *          Should be called by player w/ interact w/ entryway.
     * 
     */
    public void InvertEntryway() 
    {

        //close entryway
        if ( open )
        {
            

            //if there's an open version of the door:
            if(openDoor != null)
                //deactivate open door
                openDoor.SetActive(false);

            //activate closed door
            closedDoor.SetActive(true); 

            open = false;
        }
        //open entryway
        else
        {
            
            if (openDoor != null)
                openDoor.SetActive(true);
            
            closedDoor.SetActive(false);

            open = true;
        }

        //play door sound
        AudioManager.instance.Play("Entryway");
    }


}
