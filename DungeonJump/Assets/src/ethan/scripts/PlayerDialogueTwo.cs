using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueTwo : Dialogue
{
    protected override void PlayerDisplay(int id) 
    {
        Debug.Log("Player Dialogue Two"); 
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+1);
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+2);
    }

    public override void PlayerUIEnable()
    {
        Debug.Log("Two Player UI Enable");
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
    }

    public override void PlayerUIDisable()
    {
        Debug.Log("Two Player UI Disable");
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
    }
    
    public int GetResponse(int id)
    {
        int response;
        bool isParsable = Int32.TryParse(dialogueArr[id,1], out response);
        if (isParsable) return response;
        else return -1;
    }
}