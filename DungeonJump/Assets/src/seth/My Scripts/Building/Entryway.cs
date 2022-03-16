using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entryway : MonoBehaviour
{
    public GameObject openDoor; //public AnimationClip openAnim;
    public GameObject closedDoor; //public AnimationClip closeAnim;
    public AudioSource interactSound;
    //public bool playerEntered = false;
    //public GameObject cieling;

    private bool open = false;
    private bool entrywayInteractable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //player is in contact w/ door
        {
            entrywayInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //player is in contact w/ door
        {
            entrywayInteractable = false;
        }
    }

    public void InvertEntryway() //should be called by player w/ interact w/ entryway
    {
        if( open )
        {
            //close entryway

            openDoor.SetActive(false); //deactivate open door
            closedDoor.SetActive(true); //activate closed door

            //make cieling opaque:
            //cieling.SetActive(true);

            open = false;
        }
        else
        {
            //open entryway

            openDoor.SetActive(true);
            closedDoor.SetActive(false);

            //make cieling transparent:
            //cieling.SetActive(false);

            open = true;
        }
    }
}
