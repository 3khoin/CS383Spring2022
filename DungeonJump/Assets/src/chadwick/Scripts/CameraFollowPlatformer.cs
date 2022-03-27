using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlatformer : MonoBehaviour
{
  
    public Transform target;
    public float lerpSpeed = 2.5f;
    private Vector3 offset;
    private Vector3 targetPos;

    private void Start()
    {
        // ensure that there is a target as start
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //snap cam to target w/ offset:
        transform.position = new Vector3( target.position.x, target.position.y, target.position.z - 10f);

        offset = transform.position - target.position; //establish offset for updating

        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
}
