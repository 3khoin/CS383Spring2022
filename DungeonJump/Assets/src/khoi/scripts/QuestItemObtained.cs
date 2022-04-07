using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemObtained : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManagerTmp.instance.AddQuestItem(itemName);
        }
    }

    public void PlayerPickup()
    {
        gameObject.SetActive(false);
    }
}