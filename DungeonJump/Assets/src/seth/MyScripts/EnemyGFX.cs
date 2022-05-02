using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        //if moving to right
        if (aiPath.desiredVelocity.x >= 0.005f)
        {
            print("Scale should be flipped");

            //flip over x-axis
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //if moving to left
        else if (aiPath.desiredVelocity.x <= -0.005f)
        {
            print("Scale should be flipped");

            //revert over x-axis
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
