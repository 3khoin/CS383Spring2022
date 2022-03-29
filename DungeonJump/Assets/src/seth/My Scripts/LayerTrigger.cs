/*
 * Filename: LayerTrigger.cs 
 * Developer: Seth Cram + Cainos
 * Purpose: File for when object exit the trigger, put it to the assigned layer and sorting layers. 
 *          Used in the stair objects for player to travel between layers.
 */

using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{

    /*
     * Summary: Class for when object exit the trigger, put it to the assigned layer and sorting layers.
     *          Used in the stair objects for player to travel between layers.
     * 
     * Member Variables:
     * layer - String set externally used to change triggered GameObjects' layers.
     * sortingLayer - String set externally used to change triggered SpriteRenderers' sorting layers.
     */
    public class LayerTrigger : MonoBehaviour
    {
        public string layer;
        public string sortingLayer;

        /*
         * Summary: Changes triggered GameObject's layer and it's children's sorting layers.
         * 
         * Paramters:
         * collision - Collider2D used to determine what triggered this GameObject. 
         */
        private void OnTriggerExit2D(Collider2D other)
        {
            other.gameObject.layer = LayerMask.NameToLayer(layer);

            //unnecessary:
            //other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer; 
            //other.gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = sortingLayer;

            SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach ( SpriteRenderer sr in srs)
            {
                sr.sortingLayerName = sortingLayer;
            }
        }

    }
}
