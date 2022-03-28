using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum powerUpTypes {Speed, Jump, Health};

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public powerUpTypes powerUpType;
    public float multiplier = 1.67f;
    public float duration = 30f;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Debug.Log("Picked up power up.");

        // get the player and modify stats of the player
        LightBandit stats = player.GetComponent<LightBandit>();

        // apply power up effects
        switch(powerUpType)
        {
            case powerUpTypes.Speed : 
                stats.m_speed *= multiplier;
            break;
            case powerUpTypes.Jump :
                stats.m_jumpForce *= multiplier - .1f;
                // modify speed as well to add a balanced feel of movement
                stats.m_speed *= (multiplier - 0.47f);
            break;
            case powerUpTypes.Health :
                // do nothing
            break;
        }
        

        // disable visibility and collision of powerup
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
                stats.m_jumpForce /= multiplier - .1f;
                stats.m_speed /= (multiplier - 0.47f);
            break;
            case powerUpTypes.Health :
                // do nothing
            break;
        }
        

        Destroy(gameObject);
    }
}
