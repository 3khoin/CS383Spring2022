/*
 * Filename: Spawner.cs 
 * Developer: Seth Cram
 * Purpose: This file duplicates and spawns the provided hazard randomly within the provided bounds. 
 * 
 */

using UnityEngine;
using System.Collections;

/*
 * Summary: This class duplicates and spawns the provided hazard randomly within the provided bounds.
 * 
 * Member Variables:
 * maxX, minX, maxY, minY - Floats used to determine the bounds of spawning.
 * spawnSpeed - Float to change how quickly hazards are spawned.
 * hazard - GameObject spawned into the scene.
 * destroyDelay - Float to determine how long till a spawned hazard is destroyed.
 */
public class Spawner : MonoBehaviour
{
    public float maxX = 10;
    public float minX = -10;
    public float maxY = 10;
    public float minY = -10;
    public float spawnSpeed = 1;

    public GameObject hazard;

    public float destroyDelay = 5;

    /*
     * Summary: Repeatedly calls a function to spawn a hazard dependent on spawnSpeed.
     */
    void Start()
    {
        //repeatedly spawn a hazard:
        InvokeRepeating("SpawnHazard", 0, 1/spawnSpeed);

        //make sure destroyDelay longer than spawnDelay:
        destroyDelay = 3.5f / spawnSpeed;
    }

    /*
     * Summary: Randomly spawns a hazard within the specified bounds.
     * 
     */
    public void SpawnHazard()
    {
        //if no hazard
        if(hazard == null)
        {
            //dont spawn one
            return;
        }

        //find rando spawn vals:
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);

        //create hazard in scene:
        GameObject spawnHazard = Instantiate(hazard, new Vector3(spawnX, spawnY, 0), Quaternion.identity, transform);

        //debug: print("Hazard spawned");

        //remove hazard after some time:
        StartCoroutine(RemoveHazard(spawnHazard));
    }

    /*
     * Summary: Removes passed in spawnedObj after destroy delay.
     */
    public IEnumerator RemoveHazard( GameObject spawnedObj)
    {
        //debug:
        //Debug.Log("Hazard " + spawnedObj.name + " waiting for removal");

        //wait for destroy delay
        yield return new WaitForSeconds(destroyDelay);

        //debug:
        //Debug.Log("Hazard " + spawnedObj.name + " removed");

        //destroy passed obj
        Destroy(spawnedObj);
    }
}
