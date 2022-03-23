using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxX = 10;
    public float minX = -10;
    public float maxY = 10;
    public float minY = -10;
    public float spawnSpeed = 1;

    public GameObject hazard;

    // Start is called before the first frame update
    void Start()
    {
        //spawn a hazard every second:
        InvokeRepeating("SpawnHazard", 0, 1/spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnHazard()
    {
        //find rando spawn vals:
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);

        //create hazard in scene:
        Instantiate(hazard, new Vector3(spawnX, spawnY, 0), Quaternion.identity, transform);

        print("Hazard spawned");
    }
}
