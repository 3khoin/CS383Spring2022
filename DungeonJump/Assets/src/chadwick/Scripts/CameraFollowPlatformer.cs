/*
* Filename: CameraFollowPlatformer.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the CameraFollowPlatformer class which follows a player throughout a level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: The CameraFollowPlatformer class which is a modification of the overworld camera to account for operating in a sidescrolling platformer level
*
* Member Variables:
* target - the target of the camera (the player)
* lerpSpeed - lerpSpeed for smoothing
* offset - camera offset
* targetPos - the position of the target
*/
public class CameraFollowPlatformer : MonoBehaviour
{
  
    public Transform target;
    public float lerpSpeed = 2.5f;
    private Vector3 offset;
    private Vector3 targetPos;


    /*
    * Summary: Find the target and move the camera to that position
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    private void Start()
    {
        // ensure that there is a target as start
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //snap cam to target w/ offset:
        transform.position = new Vector3( target.position.x, target.position.y, target.position.z - 10f);
        //establish offset for updating
        offset = transform.position - target.position; 

    }


    /*
    * Summary: Adjust the camera position along with the movement of the player
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
