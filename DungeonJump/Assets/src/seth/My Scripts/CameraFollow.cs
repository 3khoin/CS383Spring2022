using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 2.5f;
        public float camOffset;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            //if not manually filled, find player at startup:
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }

            //snap cam to target w/ offset:
            transform.position = new Vector3( target.position.x, target.position.y, target.position.z + camOffset);

            offset = transform.position - target.position; //establish offset for updating

        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
