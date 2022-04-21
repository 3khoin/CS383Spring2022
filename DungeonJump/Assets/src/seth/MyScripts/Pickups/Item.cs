/* Item Prefab
 * Name: Item
 * Summary: Requiring a Collider2D that inactivates this script's object if the player comes into contact. 
 * Description: The gameobject is inactivated upon contact.
 *              Only works if interacting gameobject is tagged "Player".
 */

/*
 * Filename: Item.cs 
 * Developer: Seth Cram
 * Purpose: File requiring a Collider2D that inactivates this script's object if the player comes into contact. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class inactivates this script's object if the player comes into contact.
 * 
 */
[RequireComponent(typeof(Collider2D))]
public class Item : Interactable
{
    //public Color highlightColor;

    /*
     * Summary: Calls PlayerPickup() if triggers on the player.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    override public void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided w/ player:
        if (collision.gameObject.tag == "Player")
        {
            //have player pickup:
            PlayerPickup();
        }
    }

    /*
     * Summary: Adds this GameObject to the LevelManager's player items and makes it dissapear from the scene. 
     */
    override public void PlayerPickup()
    {
        //Add to LevelManager player's currItems:
        //LevelManager.Instance.playerCurrItems.Add(gameObject); 

        //make item dissapear:
        gameObject.SetActive(false);
    }
}
