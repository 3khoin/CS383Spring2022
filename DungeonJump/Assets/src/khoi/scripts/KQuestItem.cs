using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KQuestItem : KItem
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ClassifyItem();
        }
    }

    protected void PlayerPickup()
    {
        Debug.Log("Picked up a quest item");
        gameObject.SetActive(false);
    }

    public void ClassifyItem()
    {
        Debug.Log("This is a quest item");
    }
}