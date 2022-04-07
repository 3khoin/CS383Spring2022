using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscItemObtained : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManagerTmp.instance.AddMiscItem(itemName);
        }
    }

    public void PlayerPickup()
    {
        gameObject.SetActive(false);
    }
}