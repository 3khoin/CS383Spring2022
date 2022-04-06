/* MainCamera Prefab
 * name: MainCamera
 * Summary: Camera will follow any given target transform at given lerp speed.
 * Description: If target is not specified, the camera automatically targets the GameObject tagged as "Player".
 */

/*
 * Filename: CameraFollow.cs 
 * Developer: Seth Cram + Cainos
 * Purpose: File to let camera follow target.
 */

using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    /*
     * Summary: Class to let camera follow target.
     * 
     * Member Variables:
     * target - Transform for camera to follow.
     * lerpSpeed - Float to determine the speed at which the target is followed.
     * camOffset - Float for the camera's z-offset.
     * offset - Vector3 for calculating the right offset of camera from target.
     * targetPos - Vector3 to store the target's position.
     */
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 2.5f;
        public float camOffset = -10;

        private Vector3 offset;

        private Vector3 targetPos;

        /*
         * Summary: Sets target to player on startup if not manually set.
         *          Snaps camera to correct position. 
         *          Establishes offset for updating camera.
         * 
         */
        private void Start()
        {
            //if not manually filled, find player at startup:
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }

            //snap cam to target w/ offset:
            transform.position = new Vector3( target.position.x, target.position.y, target.position.z + camOffset);

            //establish offset for updating:
            offset = transform.position - target.position; 
        }

        /*
         * Summary: If the target is set, every frame change the camera's position 
         *          according to the target's new position.
         * 
         */
        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
