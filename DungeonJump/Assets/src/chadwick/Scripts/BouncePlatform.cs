/*
* Filename: BouncePlatform.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the BouncePlatform class which launches a player vertically
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: The BouncePlatform class which implements a platform that will launch the player upward if they walk onto it
*
* Member Variables:
* bounceHeight - the magnitude of the upward force vector applied to the player
*/
public class BouncePlatform : MonoBehaviour
{
    [SerializeField]
    public float bounceHeight = 20f;


    /*
    * Summary: Detect a collision between 2D objects
    *
    * Parameters:
    * other - separate collider entity
    *
    * Returns:
    * none
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if collided with player
        if(other.CompareTag("Player"))
        {
            // play SFX and launch the player
            FindObjectOfType<AudioManager>().Play("Bounce");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceHeight, ForceMode2D.Impulse);
        }
    }
}
