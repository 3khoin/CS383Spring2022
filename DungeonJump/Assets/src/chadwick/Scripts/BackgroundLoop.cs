using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed;

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

    // reposition children so they are always filling the screen
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

    void Update() {

        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }

    // update after each frame
    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
