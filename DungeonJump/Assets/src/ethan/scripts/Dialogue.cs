using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    protected GameObject npcUI;
    protected GameObject playerUI1;
    protected GameObject playerUI2;
    protected GameObject playerUI3;
    protected int dialogueID;
    [SerializeReference] public TextAsset jsonFile;
    public Dialog[] conversations;

    private void Start()
    {
        npcUI = NPCManager.npcUI;
        playerUI1 = NPCManager.playerUI1;
        playerUI2 = NPCManager.playerUI2;
        playerUI3 = NPCManager.playerUI3;
        dialogueID = 0;
        conversations = NPCManager.JR.ReadJSON(jsonFile);
        Debug.Log("Found " + conversations[0].firstText + " " + conversations[0].secondText + " " + conversations[0].thirdText + conversations[0].next[0]);
    }
    
    
    protected virtual void UIDisplay(int id)
    {
        Debug.Log("Default Player Display");
    }

    
    protected virtual void UIEnable()
    {
        Debug.Log("Default UI Enable");
    }

    protected virtual void UIDisable()
    {
        Debug.Log("Default UI Disable");
    }
    

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = true;
            UIEnable();
            UIDisplay(dialogueID);
        }
    }

    
    public override void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = false;
            UIDisable();
        }
    }
}