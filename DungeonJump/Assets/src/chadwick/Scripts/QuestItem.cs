/*
* Filename: QuestItem.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the quest item object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: The QuestItem class which plays a sound effect and utilizes the interactable item interface
* currently acting as skeleton code until the assembly definition problem is figured out
* Member Variables:
* none
*/
public class QuestItem :  PlatformerItem
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
    override public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(null);            
        }
    }

    /*
    * Summary: Plays a sound upon and removes the item from the scene when picking up a quest item
    *
    * Parameters:
    * other - a separate 2D collider
    *
    * Returns:
    * none
    */
    override public void Pickup(Collider2D other){
        FindObjectOfType<AudioManager>().Play("QuestItemPickup");
        Destroy(gameObject.GetComponent<ParticleSystem>());
        Destroy(gameObject);
    }
}
