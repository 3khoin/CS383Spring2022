/*
* Filename: ExitGate.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the exit gate object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Summary: The ExitGate class which implements the inter-level gates
*
* Member Variables:
* levelName - stores the name of the level that the gate will send the player to upon interaction
*/
public class ExitGate : MonoBehaviour
{
    [SerializeField]
    public string levelName = "Overworld Spawn Area";

    /*
    * Summary: Detect a collision between 2D objects
    *
    * Parameters:
    * other - separate collider entity
    *
    * Returns:
    * none
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if collide with player:
        if( collision.gameObject.tag == "Player")
        {
            //change lvl to overworld:
            SceneManager.LoadScene(levelName);
        }
    }
}
