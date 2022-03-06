using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogue : Dialogue
{
    protected override void Display(int id) 
    {
        Debug.Log("Player Dialogue");
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }
}
