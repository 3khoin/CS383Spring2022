using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    private float startingXscale;

    private void Start()
    {
        startingXscale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //if moving to right
        if (aiPath.desiredVelocity.x >= 0.005f)
        {
            print("Scale should be flipped");

            //flip over x-axis
            transform.localScale = new Vector3(-startingXscale, transform.localScale.y, transform.localScale.z);
        }
        //if moving to left
        else if (aiPath.desiredVelocity.x <= -0.005f)
        {
            print("Scale should be flipped");

            //revert over x-axis
            transform.localScale = new Vector3(startingXscale, transform.localScale.y, transform.localScale.z);
        }
    }

}
