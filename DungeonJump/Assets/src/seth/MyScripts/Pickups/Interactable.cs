/*
 * Filename: Interactable.cs 
 * Developer: Seth Cram
 * Purpose: File implemented by any script that involves player pickup. 
 * 
 */

/*
 * Summary: Interface implemented by any script that involves player pickup.
 * 
 */
public interface Interactable
{
    /*
     * Summary: Should allow the player to pickup something.
     */
    public void PlayerPickup();

    /*
     * Summary: Should play sound when picked up.
     */
    //public void PlayPickupSound();
}
