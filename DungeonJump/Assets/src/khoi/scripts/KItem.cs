using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KItem : MonoBehaviour
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
        gameObject.SetActive(false);
    }

    public virtual void ClassifyItem()
    {
        Debug.Log("This is an unclassified item");
    }
}