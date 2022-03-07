using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    //[SerializeField] public GameObject dialogueWindow; 
    [SerializeField] public int dialogueID;
    [SerializeField] public string[] dialogueArr;
    protected GameObject NPCUI;
    protected GameObject PlayerUI1;
    protected GameObject PlayerUI2;
    protected GameObject PlayerUI3;

    void Start()
    {
        //dialogueID = 0;
        NPCUI = NPCManager.NPCUI;
        PlayerUI1 = NPCManager.PlayerUI1;
        PlayerUI2 = NPCManager.PlayerUI2;
        PlayerUI3 = NPCManager.PlayerUI3;
    }
    
    protected virtual void Display(int id)
    {
        Debug.Log("Default Dialogue");
        NPCUI.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
        PlayerUI1.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+1);
        PlayerUI2.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+2);
        PlayerUI3.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id+3);
    }

    protected string FetchText(int id)
    {
        return dialogueArr[id];
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        EnableUI();
        Display(dialogueID);
        
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
        PlayerUI1.SetActive(true);
        PlayerUI2.SetActive(true);
        PlayerUI3.SetActive(true);
    }

    private void DisableUI()
    {
        Debug.Log("Conversation Disable");
        NPCUI.SetActive(false);
        PlayerUI1.SetActive(false);
        PlayerUI2.SetActive(false);
        PlayerUI3.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            dialogueID = 4;
            Display(dialogueID);
        } 
        else if (Input.GetKeyDown("2"))
        {
            dialogueID = 8;
            Display(dialogueID);
        } 
        else if (Input.GetKeyDown("3"))
        {
            dialogueID = 12;
            Display(dialogueID);
        }
    }
}

