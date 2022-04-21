/*
 * Filename: Hazard.cs 
 * Developer: Seth Cram 
 * Purpose: File used to document when player enters and exits a trigger. 
 * Notes: statically bound: Hazard haz = new Hazard()
 *        dynamically bound: ResetHazard haz = new ResetHazard()
 *        Usually, superClass varName = new SubClass or new itsClass
 *        LHS = static type, RHS = dynamic type
 *        Change dynamic type: Hazard haz = new ResetHazard(), ResetHazard's method called
 *        "virtual" means to bind on the dynamic type
 * 
 */

using UnityEngine;

/*
 * Summary: Superclass requiring a Collider2D used to document when player enters and exits a trigger.
 * 
 */
[RequireComponent(typeof(Collider2D))]
public class Hazard : MonoBehaviour
{

    /*
     * Summary: Displays message on console when player enters trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            print("hazard triggered by player entering");    
    }

    /*
     * Summary: Displays message on console when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    virtual public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            print("hazard triggered by player exiting");
    }

}
