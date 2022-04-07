using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : PlatformerItem
{
    override public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(null);     
            PlayerManagerTmp.instance.UpdatePlayerScore(100);       
        }
    }

    override public void Pickup(Collider2D other)
    {
        Destroy(gameObject);
    }
}