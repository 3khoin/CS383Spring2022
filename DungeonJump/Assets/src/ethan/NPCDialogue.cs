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
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }
    
}
