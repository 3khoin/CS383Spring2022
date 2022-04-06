using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueTwo : Dialogue
{
    protected override void UIDisplay(int id) 
    {
        //Debug.Log("Dialogue Two Display"); 
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetSecondText();
    }

    protected override void UIEnable()
    {
        //Debug.Log("Two UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
    }

    protected override void UIDisable()
    {
        //Debug.Log("Two UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
    }
    
    
    private void Update()
    {
        
        if (!interact) return;
        if (Input.GetKeyDown("1"))
        {
            //Debug.Log("Choice 1");
            dialogueID = conversations[dialogueID].GetNext(0);
            UIDisable();
            UIDisplay(dialogueID);
            if(!helpful) helpful = conversations[dialogueID].CheckQuest(0);
        } 
        else if (Input.GetKeyDown("2"))
        {
            //Debug.Log("Choice 2");
            dialogueID = conversations[dialogueID].GetNext(1);
            UIDisplay(dialogueID);
            if(!helpful) helpful = conversations[dialogueID].CheckQuest(1);
        }
    }
}