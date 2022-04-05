using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour, InteractableItem
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(null);            
        }
    }
    public void Pickup(Collider2D other){
        //if (gameObject.CompareTag("QuestItem"))
        //{
        //LevelManager.Instance.playerCurrItems.Add(gameObject);
        FindObjectOfType<AudioManager>().Play("QuestItemPickup");
        Destroy(gameObject.GetComponent<ParticleSystem>());
        Destroy(gameObject);
        //}
    }
}
