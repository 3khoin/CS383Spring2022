using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum powerUpTypes {Speed, Jump, Health};

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
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
        Debug.Log("Picked up");

        // get the player and modify stats of the player
        LightBandit stats = player.GetComponent<LightBandit>();
        stats.m_speed *= multiplier;

        // disable visibility and collision of powerup
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        //  wait time and reverse effect
        yield return new WaitForSeconds(duration);


        stats.m_speed /= multiplier;

        Destroy(gameObject);
    }
}
