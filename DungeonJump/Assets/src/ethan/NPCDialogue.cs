using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialogue : Dialogue
{
    public string[,] array =
    {
        {"My initial dialogue", "0"}, {"A positive day to you", "4"}, {"It is quite neutral today", "8"}, {"I am feeling negative today", "12"},
        {"A positive day to you too.", "0"}, {"No, a positive day to YOU.", "4"}, {"No, I have no string feelings.", "8"}, {"Just kidding, screw you", "12"},
        {"Yes, quite beige.","0"}, {"But it is so positively colorful today.","4"}, {"Yes, quite.","8"}, {"Yes, DARK BEIGE!","12"},
        {"Well I say!","0"}, {"Sorry, just had to balance out the good.","4"}, {"Life is meaningless.","8"}, {"I am sure you say!","12"}
    };
    
    protected override void Display(int id) 
    { 
        Debug.Log("NPC Dialogue"); 
        NPCUI.GetComponentInChildren<TextMeshProUGUI>().text = FetchText(id);
    }

}
