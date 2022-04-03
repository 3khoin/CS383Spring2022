using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp :  PlatformerItem
{
    public enum powerUpTypes {Speed, Jump, Health};
    public GameObject pickupEffect;
    public powerUpTypes powerUpType;
    [SerializeField]
    public float multiplier = 1.67f;
    [SerializeField]
    public float duration = 30f;
    [SerializeField]
    public float speedBalancer = .47f;
    [SerializeField]
    public float jumpBalancer = .1f;
    override public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player")){
            Pickup(other);
        }
    }

    override public void Pickup (Collider2D player)
    {
        FindObjectOfType<AudioManager>().Play("PowerUpPickup");
        StartCoroutine(PickupPowerUp(player));
    }

    private IEnumerator PickupPowerUp(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //Debug.Log("Picked up power up.");

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
                // do nothing
            break;
        }
        

        // disable visibility and collision of powerup & play SFX
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        //GetComponent<ParticleSystem>().Stop();
        
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
