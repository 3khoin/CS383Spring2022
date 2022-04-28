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
    public float followDistance;

    private Transform target; 

    // Start is called before the first frame update
    void Start() {
     
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update() {
        
        if(Vector2.Distance(transform.position, target.position) > followDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }     
    }
}
