using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscItemObtained : MonoBehaviour
{
    public string itemName;
    public AudioSource miscItemSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManagerTmp.instance.AddMiscItem(itemName);
            PlayMiscItemSound();
        }
    }

    public void PlayMiscItemSound()
    {
        miscItemSound.Play();
    }

    public void PlayerPickup()
    {
        gameObject.SetActive(false);
    }
}