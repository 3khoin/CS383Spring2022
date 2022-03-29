/*
 * Filename: Item.cs 
 * Developer: Seth Cram
 * Purpose: File adds this script's GameObject to the LevelManager's list of player items if the player comes into contact. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class adds this script's GameObject to the LevelManager's list of player items if the player comes into contact.
 * 
 */
public class Item : MonoBehaviour, Interactable
{
    //public Color highlightColor;

    /*
     * Summary: Calls PlayerPickup() if triggers on the player.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerEnter2D(Collider2D collision)
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
    public void PlayerPickup()
    {
        //Add to LevelManager player's currItems:
        LevelManager.Instance.playerCurrItems.Add(gameObject); 

        //make item dissapear:
        gameObject.SetActive(false);
    }
}
