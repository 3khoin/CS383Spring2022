/*
 * Filename: InteractableInterface.cs 
 * Developer: Seth Cram
 * Purpose: File used as an interface for interactables. 
 * Notes: Bridge Interface
 *      Chosen for its expandability, in case multiple types of powerups and items needed. 
 *      Separates implementation from interface. Beyond encapsulation to insulation.
 *      
 *      If interface classes delegate the creation of their implementation classes (instead of creating/coupling themselves directly), 
 *      then the design usually uses the Abstract Factory pattern to create the implementation objects.
 *      
 *      An adaptor is better if the code is already written. Easier plug and play.
 */

/*
 * Summary: Interface implemented by any script that involves player pickup.
 * 
 */
public interface InteractableInterface
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
