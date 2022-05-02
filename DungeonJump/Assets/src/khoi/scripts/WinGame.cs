using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            WinTheGame();
        }
    }

    public void WinTheGame()
    {
        PlayerManagerTmp.instance.WinGame();
    }
}