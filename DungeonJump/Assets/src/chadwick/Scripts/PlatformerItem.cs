using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerItem : MonoBehaviour, InteractableItem
{
    virtual public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player")){
            Pickup(other);
        }
    }
    virtual public void Pickup(Collider2D other){
        Debug.Log("Picked up an item.");
    }
}
