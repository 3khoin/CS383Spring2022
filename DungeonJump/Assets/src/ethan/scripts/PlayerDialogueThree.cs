using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogueThree : Dialogue
{
    [SerializeField] protected string questItem;
    
    protected override void UIDisplay(int id) 
    {
        //Debug.Log("Dialogue Three Display"); 
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetSecondText();
        playerUI3.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetThirdText();
    }

    
    protected override void UIEnable()
    {
        //Debug.Log("Three UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
        playerUI3.SetActive(true);
    }

    protected override void UIDisable()
    {
        //Debug.Log("Three UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
        playerUI3.SetActive(false);
    }
    
    
    private void Update()
    {
        if (!interact) return;
        if (PlayerManagerTmp.instance.QuestItemIsCollected(questItem) && !questEnd) dialogueID = 2;
        if (Input.GetKeyDown("1"))
        {
            //Debug.Log("Choice 1");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(0);
            else LevelManager.Instance.RemoveProgressBlocks();
            
            if (!questStart) questStart = conversations[dialogueID].CheckQuest(0);
            if (!PlayerManagerTmp.instance.QuestItemIsCollected(questItem) || questEnd) dialogueID = conversations[dialogueID].GetNext(0);
            
            UIDisable();
            UIDisplay(dialogueID);
        } 
        else if (Input.GetKeyDown("2"))
        {
            //Debug.Log("Choice 2");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(1);
            else LevelManager.Instance.RemoveProgressBlocks();

            if (!questStart) questStart = conversations[dialogueID].CheckQuest(1);
            if (!PlayerManagerTmp.instance.QuestItemIsCollected(questItem) || questEnd) dialogueID = conversations[dialogueID].GetNext(1);
            
            UIDisplay(dialogueID);
        }
        else if (Input.GetKeyDown("3"))
        {
            //Debug.Log("Choice 3");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(2);
            else LevelManager.Instance.RemoveProgressBlocks();
            
            if (!questStart) questStart = conversations[dialogueID].CheckQuest(2);
            if (!PlayerManagerTmp.instance.QuestItemIsCollected(questItem) || questEnd) dialogueID = conversations[dialogueID].GetNext(2);
            
            UIDisplay(dialogueID);
        }
    }
}