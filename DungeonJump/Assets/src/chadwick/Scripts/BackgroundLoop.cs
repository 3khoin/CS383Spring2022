/*
* Filename: BackgroundLoop.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the BackgroundLoop class which loops the background images continuously for a platformer level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: The BackgroundLoop class which effectively is supposed to allow for an infinitely scrolling platformer background
*
* Member Variables:
* levels - the different background images
* mainCamera - the camera
* screenBounds - the calculated visible screen bounds
* choke - used in repositioning the backgrounds
* scrollSpeed - how fast the camera is moving so the rate at which the backgrounds should be drawn can be known
*/
public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed;


    /*
    * Summary: Find the screen bounds necessary for drawing the background
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        // get screen width and height then plot on xy axes
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        // for each object we want loaded into the scene call LoadChildObjects
        foreach(GameObject obj in levels)
        {
            LoadChildObjects(obj);
        }
    }


    /*
    * Summary: Gathers and loads all of the objects which make up the background
    *
    * Parameters:
    * obj -  a gameObject to be displayed on the screen
    *
    * Returns:
    * none
    */
    private void LoadChildObjects(GameObject obj)
    {
        // find screen width of obj
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        // Find out how many clones are needed to fill screen
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 3/ objectWidth) + 1;
        // Make a clone
        GameObject clone = Instantiate(obj) as GameObject;

        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            // make the clone a child of the parent that it's instantiated from
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        // destroy clone so as not to clone clones in future iterations
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }


/*
    * Summary: reposition the game objects that make up the background of the level
    *
    * Parameters:
    * obj -  a gameObject to be repositioned on the screen
    *
    * Returns:
    * none
    */
    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            // get the first and last child objects 
            GameObject firstChild =  children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            // get half of the width because when modifying the tranform by adding/subtracting half the width, the transform will be at the edge of the object
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            // check if camera screen bounds are extending past current child being drawn on screen and rearrange the child if so
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,  lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }


/*
    * Summary: Smooth the scrollspeed of the level
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void Update() {

        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }


    /*
    * Summary: update after each frame
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
