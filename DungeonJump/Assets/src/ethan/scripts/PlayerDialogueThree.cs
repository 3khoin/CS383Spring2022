using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueThree : Dialogue
{
    protected override void PlayerDisplay(int id) 
    {
        Debug.Log("Player Dialogue Three");
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+1);
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+2);
        playerUI3.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+3);
    }

    public override void PlayerUIEnable()
    {
        Debug.Log("Three Player UI Enable");
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
        playerUI3.SetActive(true);
    }

    public override void PlayerUIDisable()
    {
        Debug.Log("Three Player UI Disable");
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
        playerUI3.SetActive(false);
    }
    
    public int GetResponse(int id)
    {
        int response;
        bool isParsable = Int32.TryParse(dialogueArr[id,1], out response);
        if (isParsable) return response;
        else return -1;
    }
}