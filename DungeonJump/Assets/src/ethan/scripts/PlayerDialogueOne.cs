using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueOne : Dialogue
{
    
    
    protected override void UIDisplay(int id) 
    {
        Debug.Log("Dialogue One Display");
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
    }
    
    protected override void UIEnable()
    {
        Debug.Log("One UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
    }

    protected override void UIDisable()
    {
        Debug.Log("One UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
    }
    
    
    private void Update()
    {
        
        if (!interact) return;
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Choice 1");
            dialogueID = conversations[dialogueID].GetNext(0);
            UIDisplay(dialogueID);
        }
    }
}
