using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialogue : Dialogue
{
    
    protected override void Display(int id) 
    { 
        Debug.Log("NPC Dialogue"); 
        NPCUI.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }

    public override void NPCUIEnable()
    {
        Debug.Log("NPC UI Enable");
        NPCUI.SetActive(true);
    }

    public override void NPCUIDisable()
    {
        Debug.Log("NPC UI Disable");
        NPCUI.SetActive(false);
    }
    
}
