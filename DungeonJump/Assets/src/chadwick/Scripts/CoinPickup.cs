using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : PlatformerItem
{
    override public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(null);            
        }
    }

    override public void Pickup(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("CoinPickup");
        Destroy(gameObject);
    }
}
