/* Item Prefab
 * Name: Interactable
 * Summary: A gameobject that's added to the player's inventory when triggered.
 * Description: Only works if interacting gameobject is tagged "Player".
 */

/*
 * Filename: Interactable.cs 
 * Developer: Seth Cram
 * Purpose: File requiring a Collider2D that calls PlayerPickup if the player comes into contact. 
 * 
 */

using UnityEngine;

/*
 * Summary: Superclass that calls PlayerPickup if the player comes into contact.
 * 
 */
[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour, InteractableInterface
{
    //public Color highlightColor;

    /*
     * Summary: Calls PlayerPickup() if triggers on the player.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided w/ player:
        if (collision.gameObject.tag == "Player")
        {
            //have player pickup:
            PlayerPickup();
        }
    }

    /*
     * Summary: Calls pickup message for confirmation. 
     */
    virtual public void PlayerPickup()
    {
        print("Player should pickup item.");
    }
}
