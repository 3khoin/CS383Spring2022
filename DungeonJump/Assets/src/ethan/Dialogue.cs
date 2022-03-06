using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    [SerializeField] public GameObject dialogueWindow; 
    public int dialogueID;
    [SerializeField] public int initID;
    public string[] dialogueArr = {"hello", "goodbye", "dialogue id 2"};

    void Start()
    {
        dialogueID = initID;
    }
    
    protected virtual void Display(int id)
    {
        Debug.Log("Default Dialogue");
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
        dialogueWindow.SetActive(true);
        Display(initID);
    }

    private void DisableUI()
    {
        Debug.Log("Conversation Disable");
        dialogueWindow.SetActive(false);
    }
}

