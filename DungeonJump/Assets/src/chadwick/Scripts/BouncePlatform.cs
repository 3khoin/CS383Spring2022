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
    //void OnTriggerEnter2D(Collider2D other)
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("collided with " + other.gameObject.name);

        // check if collided with player
        //if(other.CompareTag("Player"))
        //if (other.gameObject.tag == "Player")
        //{
        // play SFX and launch the player
        //FindObjectOfType<AudioManager>().Play("Bounce");

        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();

        AudioManager.instance.Play("Bounce");

        //launch colliding obj taking into account mass (and x scale * other.gameObject.transform.localScale.x?)
        otherRB.AddForce(Vector2.up * bounceHeight * otherRB.mass , ForceMode2D.Impulse); 

       // }
    }
}
