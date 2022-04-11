/*
* Filename: CoinPickup.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for picking up a coin object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: Class for picking up a coin
*
* Member Variables:
* none
*/
public class CoinPickup : PlatformerItem
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
    * Summary: Play the coin pickup sound upon interacting with the coin
    *
    * Parameters:
    * other - a separate collider entity that interacted with the coin
    *
    * Returns:
    * none
    */
    override public void Pickup(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("CoinPickup");
        PlayerManagerTmp.instance.UpdatePlayerScore(100);
        Destroy(gameObject);
    }
}
