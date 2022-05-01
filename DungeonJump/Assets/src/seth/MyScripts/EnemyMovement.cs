/*
 * Filename: EnemyMovement.cs 
 * Developer: Seth Cram + Dawson Burgess
 * Purpose: File for 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Class for when 
 * 
 * Member Variables:
 * speed - 
 * followDistance - 
 * target - 
 */

public class EnemyMovement : MonoBehaviour {
    
    public float speed;
        // public float rotSpeed;
    public float followDistance;

    private Transform target; 

    // Start is called before the first frame update
    void Start() {
     
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //check what dir to face every 0.5s
        //InvokeRepeating("FaceDirMoving", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        
        if(Vector2.Distance(transform.position, target.position) > followDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //rotate in direction traveling
            /*
            var targetPoint = new Vector3(target.position.x, transform.position.y, target.position.z);

            //store direction calc'd from target + curr pos's (normalized so 0-1)
            Vector3 dir = (targetPoint - transform.position).normalized;

            //rot to look in dir
            Quaternion lookRot = Quaternion.LookRotation(dir);

            //apply rot to target dir
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 360);
            */
        }     
    }

    /*
     * Assumes starting direction is facing left.
     */
    void FaceDirMoving()
    {
        /*
        if (target.position.x < transform.position.x)
        {
            print("target x " + target.position.x + " is less than " + transform.position.x);

            //face left
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                0,
                transform.eulerAngles.y);
        }
        else if (target.position.x > transform.position.x)
        {
            print("target x " + target.position.x + " is greater than " + transform.position.x);

            //face right
            transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            180,
            transform.eulerAngles.y);
        }
        */
    }
}
