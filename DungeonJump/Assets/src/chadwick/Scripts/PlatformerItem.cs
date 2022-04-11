/*
* Filename: PlatformerItem.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the Platformer item class
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: The PlatformerItem class which utilizes the InteractableItem interface and is a superclass of all instantiated items
*
* Member Variables:
* none
*/
public class PlatformerItem : MonoBehaviour, InteractableItem
{
    /*
    * Summary: Detect a collision between 2D objects
    *
    * Parameters:
    * other - separate collider entity
    *
    * Returns:
    * none
    */
    virtual public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player")){
            Pickup(other);
        }
    }


    /*
    * Summary: Print a debug log statement stating that the item has been picked up
    *
    * Parameters:
    * other - a separate collider entity that interacted with the item
    *
    * Returns:
    * none
    */
    virtual public void Pickup(Collider2D other){
        Debug.Log("Picked up an item.");
    }
}
