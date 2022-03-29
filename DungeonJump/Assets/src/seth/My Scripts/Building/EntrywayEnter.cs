/*
 * Filename: EntrywayEnter.cs 
 * Developer: Seth Cram 
 * Purpose: File sets cieling to visible when player exits this GameObject's trigger. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class sets cieling to visible when player exits this GameObject's trigger.
 * 
 * Member Variables:
 * cieling - GameObject set externally to allow activeating of cieling.
 */
public class EntrywayEnter : MonoBehaviour
{
    public GameObject cieling;

    /*
     * Summary: Turns cieling visible when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            cieling.SetActive(false);
        }
    }
}
