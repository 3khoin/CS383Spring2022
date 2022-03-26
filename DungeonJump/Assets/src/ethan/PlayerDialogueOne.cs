using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueOne : Dialogue
{
    protected override void Display(int id) 
    {
        Debug.Log("Player Dialogue");
        PlayerUI1.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
        //PlayerUI2.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
        //PlayerUI3.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }
    
    public override void PlayerUIEnable()
    {
        Debug.Log("One Player UI Enable");
        PlayerUI1.SetActive(true);
    }

    public override void PlayerUIDisable()
    {
        Debug.Log("One Player UI Disable");
        PlayerUI1.SetActive(false);
    }
    
    public int GetResponse(int id)
    {
        int response;
        bool isParsable = Int32.TryParse(dialogueArr[id,1], out response);
        if (isParsable) return response;
        else return -1;
    }
}
