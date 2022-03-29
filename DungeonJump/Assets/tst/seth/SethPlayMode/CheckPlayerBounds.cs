/*
 * Filename: CheckPlayerBounds.cs 
 * Developer: Seth Cram
 * Purpose: File teleports gameobject back to spawnpoint if outside of bounds. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class teleports gameobject back to spawnpoint if outside of bounds. 
 *          Should be attached to player in overworld.
 * 
 * Member Variables:
 * spawnPnt - Transform for player spawn point.
 * leftmostPnt - Transform for leftmost point a player should go.
 * rightmostPnt - Transform for rightmost point a player should go.
 * topmostPnt - Transform for topmost point a player should go.
 * botmostPnt - Transform for botmost point a player should go.
 */
public class CheckPlayerBounds : MonoBehaviour
{
    public Transform spawnPnt;

    //boundary transforms:
    public Transform leftmostPnt;
    public Transform rightmostPnt;
    public Transform topmostPnt;
    public Transform botmostPnt;

    /*
     * Summary: Fills spawnpoint and boundary fields of current scene.
     */
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

    /*
     * Summary: If player is out of bounds, teleports them to the spawn point.
     * 
     */
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
