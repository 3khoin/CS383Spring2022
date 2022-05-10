/*
* Filename: PowerUp.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the PowerUp item class
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: Class for picking up a power up in a platformer level
*
* Member Variables:
* powerUpTypes - an enum of the different possible types of power ups
* powerUpType - self explanatory; speed/jump/health
* multiplier - numerical multiplier which modifies a player stat
* duration - the duration in time that the power up will last
* speed/jumpBalancer - a numerical value for making the effects of the power up feel smoother in gameplay
*/
public class PowerUp :  PlatformerItem
{
    public enum powerUpTypes {Speed, Jump, Health};
    public powerUpTypes powerUpType;
    [SerializeField]
    public float multiplier = 1.67f;
    [SerializeField]
    public float duration = 30f;
    [SerializeField]
    public float speedBalancer = .47f;
    [SerializeField]
    public float jumpBalancer = .1f;


    /*
    * Summary: Detect a collision between 2D objects
    *
    * Parameters:
    * other - separate collider entity
    *
    * Returns:
    * none
    */
    override public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }


    /*
    * Summary: Plays a power up pickup SFX and then begins the coroutine for the powerup
    *
    * Parameters:
    * player - the player that has collided with the power up
    *
    * Returns:
    * none
    */
    override public void Pickup (Collider2D player)
    {
        //use the singleton as a singleton
        AudioManager.instance.Play("PowerUpPickup");

        StartCoroutine(PickupPowerUp(player));
    }


    /*
    * Summary: The coroutine which is activer for the duration of the power up
    * applies the effects of the power up to the player and expires after some time
    *
    * Parameters:
    * player - the player that has collided with the power up
    *
    * Returns:
    * IEnumerator - Unity coroutine specific type
    */
    private IEnumerator PickupPowerUp(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //Debug.Log("Picked up power up.");

        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject.GetComponent<ParticleSystem>());

        // get the player and modify stats of the player
        LightBandit stats = player.GetComponent<LightBandit>();

        // apply power up effects
        switch(powerUpType)
        {
            case powerUpTypes.Speed : 
                stats.m_speed *= multiplier;
            break;
            case powerUpTypes.Jump :
                stats.m_jumpForce *= multiplier - jumpBalancer;
                // modify speed as well to add a balanced feel of movement
                stats.m_speed *= (multiplier - speedBalancer);
            break;
            case powerUpTypes.Health :
                PlayerManagerTmp.instance.UpdatePlayerHealth(.30f);
            break;
        }
        
        //  wait time and reverse effect
        yield return new WaitForSeconds(duration);

        // revert power up effects
        switch(powerUpType)
        {
            case powerUpTypes.Speed : 
                stats.m_speed /= multiplier;
            break;
            case powerUpTypes.Jump :
                stats.m_jumpForce /= multiplier - jumpBalancer;
                stats.m_speed /= (multiplier - speedBalancer);
            break;
            case powerUpTypes.Health :
                // do nothing
            break;
        }
        

        Destroy(gameObject);
    }
}
