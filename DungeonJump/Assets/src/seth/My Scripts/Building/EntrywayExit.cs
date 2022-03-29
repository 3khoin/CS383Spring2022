/*
 * Filename: EntrywayExit.cs 
 * Developer: Seth Cram 
 * Purpose: File sets cieling to invisible when player exits this GameObject's trigger. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class sets cieling to invisible when player exits this GameObject's trigger.
 * 
 * Member Variables:
 * cieling - GameObject set externally to allow inactiveating of cieling.
 */
public class EntrywayExit : MonoBehaviour
{
    public GameObject cieling;

    /*
     * Summary: Turns cieling invisible when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cieling.SetActive(true);
        }
    }
}
