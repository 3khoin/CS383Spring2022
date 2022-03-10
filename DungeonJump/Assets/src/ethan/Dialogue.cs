using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;


public class Dialogue : FriendlyNPC
{
    //[SerializeField] public GameObject dialogueWindow; 
    private int dialogueID;
    protected string[,] dialogueArr =
    {
        {"My initial dialogue", "0"}, {"A positive day to you", "4"}, {"It is quite neutral today", "8"}, {"I am feeling negative today", "12"},
        {"A positive day to you too.", "0"}, {"No, a positive day to YOU.", "4"}, {"No, I have no string feelings.", "8"}, {"Just kidding, screw you", "12"},
        {"Yes, quite beige.","0"}, {"But it is so positively colorful today.","4"}, {"Yes, quite.","8"}, {"Yes, DARK BEIGE!","12"},
        {"Well I say!","0"}, {"Sorry, just had to balance out the good.","4"}, {"Life is meaningless.","8"}, {"I am sure you say!","12"}
    };
    protected GameObject NPCUI;
    protected GameObject PlayerUI1;
    protected GameObject PlayerUI2;
    protected GameObject PlayerUI3;
    //public NPCDialogue npcDialogue;

    void Start()
    {
        dialogueID = 0;
        //dialogueArr = npcDialogue.array;
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
        Debug.Log(dialogueArr[id,0]);
        return dialogueArr[id,0];
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.gameObject.CompareTag("Player")) // if player collision end
        { 
            EnableUI();
            Display(dialogueID);
        }
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            DisableUI();
        }
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
            Debug.Log("Choice 1");
            dialogueID = 4;
            Display(dialogueID);
        } 
        else if (Input.GetKeyDown("2"))
        {
            Debug.Log("Choice 2");
            dialogueID = 8;
            Display(dialogueID);
        } 
        else if (Input.GetKeyDown("3"))
        {
            Debug.Log("Choice 3");
            dialogueID = 12;
            Display(dialogueID);
        }
    }
}