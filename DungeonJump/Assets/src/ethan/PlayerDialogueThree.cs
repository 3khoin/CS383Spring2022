using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueThree : Dialogue
{
    protected override void Display(int id) 
    {
        Debug.Log("Player Dialogue");
        PlayerUI1.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
        PlayerUI2.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
        PlayerUI3.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }

    public override void PlayerUIEnable()
    {
        Debug.Log("Three Player UI Enable");
        PlayerUI1.SetActive(true);
        PlayerUI2.SetActive(true);
        PlayerUI3.SetActive(true);
    }

    public override void PlayerUIDisable()
    {
        Debug.Log("Three Player UI Disable");
        PlayerUI1.SetActive(false);
        PlayerUI2.SetActive(false);
        PlayerUI3.SetActive(true);
    }
    
    public int GetResponse(int id)
    {
        int response;
        bool isParsable = Int32.TryParse(dialogueArr[id,1], out response);
        if (isParsable) return response;
        else return -1;
    }
}