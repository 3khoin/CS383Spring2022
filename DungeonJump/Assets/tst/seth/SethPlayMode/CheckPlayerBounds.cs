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
        //fill spawn position:
        spawnPnt = GameObject.FindGameObjectWithTag("Spawn").transform;

        //fill all boundary positions: (w/ objs already in scene)
        leftmostPnt = GameObject.FindGameObjectWithTag("left").transform;
        rightmostPnt = GameObject.FindGameObjectWithTag("right").transform;
        topmostPnt = GameObject.FindGameObjectWithTag("top").transform;
        botmostPnt = GameObject.FindGameObjectWithTag("bot").transform;
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

            Debug.LogWarning("Player caught outside of map boundaries at: " + transform.position);
            //print(transform.position);

            //teleport player back to spawn pnt:
            transform.position = spawnPnt.position;

            print("Player position changed to: " + transform.position);
            //print(transform.position);

        }

    }
}
