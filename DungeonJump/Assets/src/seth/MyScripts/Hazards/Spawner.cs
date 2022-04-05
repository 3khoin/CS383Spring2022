/*
 * Filename: Spawner.cs 
 * Developer: Seth Cram
 * Purpose: This file duplicates and spawns the provided hazard randomly within the provided bounds. 
 * 
 */

using UnityEngine;

/*
 * Summary: This class duplicates and spawns the provided hazard randomly within the provided bounds.
 * 
 * Member Variables:
 * maxX, minX, maxY, minY - Floats used to determine the bounds of spawning.
 * spawnSpeed - Float to change how quickly hazards are spawned.
 * hazard - GameObject spawned into the scene.
 */
public class Spawner : MonoBehaviour
{
    public float maxX = 10;
    public float minX = -10;
    public float maxY = 10;
    public float minY = -10;
    public float spawnSpeed = 1;

    public GameObject hazard;

    /*
     * Summary: Repeatedly calls a function to spawn a hazard dependent on spawnSpeed.
     */
    void Start()
    {
        //repeatedly spawn a hazard:
        InvokeRepeating("SpawnHazard", 0, 1/spawnSpeed);
    }

    /*
     * Summary: Randomly spawns a hazard within the specified bounds.
     * 
     */
    private void SpawnHazard()
    {
        //find rando spawn vals:
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);

        //create hazard in scene:
        Instantiate(hazard, new Vector3(spawnX, spawnY, 0), Quaternion.identity, transform);

        //debug: print("Hazard spawned");
    }
}
