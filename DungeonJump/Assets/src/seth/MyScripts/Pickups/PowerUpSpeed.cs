/*
 * Filename: PowerUpSpeed.cs 
 * Developer: Seth Cram
 * Purpose: File calls PlayerPickup() if triggers on the player.
 *          Also increases player movement speed.
 */

using UnityEngine;

/*
 * Summary: Class increases player speed when picked up and makes attached GameObject inactive.
 * 
 * Member Variables:
 * incrAmt - Float to increase Speed by. Value should only be negative to decrease player speed.
 * 
 */
public class PowerUpSpeed : MonoBehaviour, Interactable
{
    public float incrAmt = 0.1f;

    /*
     * Summary: Function calls PlayerPickup() if triggers on the player.
     *          Also increases player movement speed.
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

            //increase player's speed:
            float moveSpeed = collision.gameObject.GetComponent<MainPlayer>().moveSpeed;

            //increases by incrAmt of og move speed
            collision.gameObject.GetComponent<MainPlayer>().moveSpeed += moveSpeed * incrAmt; 
        }
    }

    /*
     * Summary: Makes this GameObject dissapear from the scene. 
     */
    public void PlayerPickup()
    {
        //make item dissapear:
        gameObject.SetActive(false);

    }
}
