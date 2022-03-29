/*
 * Filename: PowerUpSpeed.cs 
 * Developer: Seth Cram
 * Purpose: File calls PlayerPickup() if triggers on the player.
 *          Also increases player movement speed.
 */

using UnityEngine;

public class PowerUpSpeed : MonoBehaviour, Interactable
{
    public float incrAmt = 0.1f;

    /*
     * Summary: Class calls PlayerPickup() if triggers on the player.
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
            collision.gameObject.GetComponent<MainPlayer>().moveSpeed += moveSpeed * incrAmt; //increases by incrAmt of og move speed
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