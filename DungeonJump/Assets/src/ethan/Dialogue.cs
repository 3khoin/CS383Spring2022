using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    //[SerializeField] public GameObject dialogueWindow; 
    public int dialogueID;
    [SerializeField] public int initID;
    public string[] dialogueArr = {"hello", "goodbye", "dialogue id 2"};
    protected GameObject NPCUI;
    protected GameObject PlayerUI1;
    protected GameObject PlayerUI2;
    protected GameObject PlayerUI3;

    void Start()
    {
        dialogueID = initID;
        NPCUI = NPCManager.NPCUI;
        PlayerUI1 = NPCManager.PlayerUI1;
        PlayerUI2 = NPCManager.PlayerUI2;
        PlayerUI3 = NPCManager.PlayerUI3;
    }
    
    protected virtual void Display(int id)
    {
        Debug.Log("Default Dialogue");
        NPCUI.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }

    protected string FetchText(int id)
    {
        return dialogueArr[id];
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        EnableUI();
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        DisableUI();
    }
    
    private void EnableUI()
    {
        Debug.Log("Conversation Enable");
        NPCUI.SetActive(true);
        Display(initID);
    }

    private void DisableUI()
    {
        Debug.Log("Conversation Disable");
        NPCUI.SetActive(false);
    }
}

