using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMiscItem : MonoBehaviour
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
        Debug.Log("Picked up a miscellaneous item");
        gameObject.SetActive(false);
    }

    public void ClassifyItem()
    {
        Debug.Log("This is a miscellaneous item");
        KPickupInterface baseItem = new KPickup();
        if (PlayerManagerTmp.instance.GetPlayerScore() < 1000)
        {
            Debug.Log(string.Format("Speed bonus obtained: {0}", baseItem.GetSpeedBonus()));
        }
        else
        {
            KPickupInterface smallItem = new KPickupSmallDecorator(baseItem);
            Debug.Log(string.Format("Speed bonus obtained: {0}", smallItem.GetSpeedBonus()));
        }
    }
}