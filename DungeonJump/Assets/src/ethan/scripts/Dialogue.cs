using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    protected int dialogueID;
    protected string[,] dialogueArr =
    {
        {"My initial dialogue", "0"}, {"A positive day to you", "4"}, {"It is quite neutral today", "8"}, {"I am feeling negative today", "12"},
        {"A positive day to you too.", "0"}, {"No, a positive day to YOU.", "4"}, {"No, I have no string feelings.", "8"}, {"Just kidding, screw you", "12"},
        {"Yes, quite beige.","0"}, {"But it is so positively colorful today.","4"}, {"Yes, quite.","8"}, {"Yes, DARK BEIGE!","12"},
        {"Well I say!","0"}, {"Sorry, just had to balance out the good.","4"}, {"Life is meaningless.","8"}, {"I am sure you say!","12"}
    };
    protected GameObject npcUI;
    protected GameObject playerUI1;
    protected GameObject playerUI2;
    protected GameObject playerUI3;

    void Start()
    {
        dialogueID = 0;
        npcUI = NPCManager.npcUI;
        playerUI1 = NPCManager.playerUI1;
        playerUI2 = NPCManager.playerUI2;
        playerUI3 = NPCManager.playerUI3;
    }
    
    
    protected virtual void PlayerDisplay(int id)
    {
        Debug.Log("Default Player Display");
    }


    protected string FetchText(int id)
    {
        //Debug.Log(dialogueArr[id,0]);
        return dialogueArr[id,0];
    }

    
    public override void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = true;
            NPCUIEnable();
            PlayerUIEnable();
            NPCDisplay(dialogueID);
            PlayerDisplay(dialogueID);
        }
    }

    
    public override void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = false;
            NPCUIDisable();
            PlayerUIDisable();
        }
    }


    public virtual void PlayerUIEnable()
    {
        Debug.Log("Default Player UI Enable");
    }

    public virtual void PlayerUIDisable()
    {
        Debug.Log("Default Player UI Disable");
    }

    protected void NPCDisplay(int id) 
    { 
        Debug.Log("NPC Dialogue"); 
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }

    
    public void NPCUIEnable()
    {
        Debug.Log("NPC UI Enable");
        npcUI.SetActive(true);
    }

    
    public void NPCUIDisable()
    {
        Debug.Log("NPC UI Disable");
        npcUI.SetActive(false);
    }
}