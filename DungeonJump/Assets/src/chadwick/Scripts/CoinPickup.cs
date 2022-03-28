using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            coins++; // need level manager to do this
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            Destroy(gameObject);
        }
    }
}
