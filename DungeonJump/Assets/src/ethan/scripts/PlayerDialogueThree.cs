using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueThree : Dialogue
{
    
    
    protected override void UIDisplay(int id) 
    {
        Debug.Log("Dialogue Three Display"); 
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetSecondText();
        playerUI3.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetThirdText();
    }

    
    protected override void UIEnable()
    {
        Debug.Log("Three UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
        playerUI3.SetActive(true);
    }

    protected override void UIDisable()
    {
        Debug.Log("Three UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
        playerUI3.SetActive(false);
    }
    
    
    private void Update()
    {
        if (!interact) return;
        if (Input.GetKeyDown("1"))
        {
            //Debug.Log("Choice 1");
            dialogueID = conversations[dialogueID].GetNext(0);
            UIDisplay(dialogueID);
            if(!helpful) helpful = conversations[dialogueID].CheckQuest(0);
            if(!harmful) harmful = conversations[dialogueID].CheckBane(0);;
        } 
        else if (Input.GetKeyDown("2"))
        {
            //Debug.Log("Choice 2");
            dialogueID = conversations[dialogueID].GetNext(1);
            UIDisplay(dialogueID);
            if(!helpful) helpful = conversations[dialogueID].CheckQuest(1);
            if(!harmful) harmful = conversations[dialogueID].CheckBane(1);;
        }
        else if (Input.GetKeyDown("3"))
        {
            //Debug.Log("Choice 3");
            dialogueID = conversations[dialogueID].GetNext(2);
            UIDisplay(dialogueID);
            if(!helpful) helpful = conversations[dialogueID].CheckQuest(2);
            if(!harmful) harmful = conversations[dialogueID].CheckBane(2);;
        }
    }
}