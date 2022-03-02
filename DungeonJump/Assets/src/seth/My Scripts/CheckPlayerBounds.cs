using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should be attached to player in overworld
public class CheckPlayerBounds : MonoBehaviour
{
    public Transform spawnPnt;

    //boundary transforms:
    public Transform leftmostPnt;
    public Transform rightmostPnt;
    public Transform topmostPnt;
    public Transform botmostPnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player out of bounds (have to use abs vals incase negative):
        if( leftmostPnt.position.x > (transform.position.x) ||
            (rightmostPnt.position.x) < (transform.position.x) ||
            (topmostPnt.position.y) < (transform.position.y) ||
            (botmostPnt.position.y) > (transform.position.y))
        {
            //teleport player back to spawn pnt:
            transform.position = spawnPnt.position;

            Debug.LogWarning("Player caught outside of map boundaries.");
        }

    }
}
