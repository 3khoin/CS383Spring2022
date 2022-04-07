using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour, Interactable
{
    public float updateHealth = -0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManagerTmp.instance.UpdatePlayerHealth(updateHealth);
        }
    }

    public void PlayerPickup()
    {
        gameObject.SetActive(false);
    }
}
