/*
 * Filename: StaticDmgHazard.cs 
 * Developer: Seth Cram
 * Purpose: File to implement a Static player Damaging Hazard.
 */

using UnityEngine;

/*
 * Summary: Class to repeatedly damage the player if they're triggering the hazard.
 * 
 * Member Variables:
 * dmg - Float to apply damage to player.
 * reDmgDelay - Time in seconds waited till dmg should be applied again to player.
 * target - GameObject of player that is triggering the damaging hazard.
 * soundFX - String set to specify desired sound effect to play.
 */
public class StaticDmgHazard : Hazard
{
    public float dmg = -0.1f;
    public float reDmgDelay = 0.5f;
    public string soundFX = "HurtPlayer";

    private GameObject target;

    /*
     * Summary: When player enters the trigger, its set as the target and should be damaged.
     *          Overriden methods use dynamic binding.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    override public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        //if collid w/ player:
        if( collision.gameObject.tag == "Player")
        {
            //store player to damage:
            target = collision.gameObject;

            //damage player immediately
            DamagePlayer();
        }
    }

    /*
     * Summary: When player exits the trigger, it's no longer set as the target.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        //if collide w/ player exiting:
        if (collision.gameObject.tag == "Player")
        {
            //clear player so not re-damaged:
            target = null;
        }
    }

    /*
     * Summary: When player enters the collider, its set as the target and should be damaged.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collid w/ player:
        if (collision.gameObject.tag == "Player")
        {
            //store player to damage:
            target = collision.gameObject;

            //damage player immediately
            DamagePlayer();
        }
    }

    /*
     * Summary: When player exits the collider, it's no longer set as the target.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if collide w/ player exiting:
        if (collision.gameObject.tag == "Player")
        {
            //clear player so not re-damaged:
            target = null;
        }
    }

    /*
     * Summary: If the target is set, repeatedly damage the player until it's cleared.
     * 
     */
    private void DamagePlayer()
    {
        //if target exited:
        if (target == null)
        {
            return; //dont damage
        }

        //dmg player:
        PlayerManagerTmp.instance.UpdatePlayerHealth(dmg);
    
        print("Damage Player " + dmg);

        //play sound:
        AudioManager.instance.Play(soundFX);

        //try damaging player again in 0.5s:
        Invoke("DamagePlayer", reDmgDelay);
    }
}
