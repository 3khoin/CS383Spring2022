/*
 * Filename: PlayerDialogueTwo.cs
 * Developer: Ethan
 * Purpose: Subclass of Dialogue
 */


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * Summary: This class is the subclass for dialogue that allows two dialogue options for users (1 is exit dialogue, 2 advances the dialogue)
 *
 * Member Variables: none
 */
public class PlayerDialogueTwo : Dialogue
{
    /*
     * Summary: override that displays the text of the conversation corresponding to the current id
     *
     * Parameters: the current id of the dialogue to display
     *
     * Returns: none
     */
    protected override void UIDisplay(int id) 
    {
        //Debug.Log("Dialogue Two Display"); 
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetSecondText();
    }

    
    /*
     * Summary: override that enables the ui window with two dialogue options
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIEnable()
    {
        //Debug.Log("Two UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
    }

    
    /*
     * Summary: override that disables the ui window with two dialogue options
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIDisable()
    {
        //Debug.Log("Two UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
    }
    
    
    /*
     * Summary: update handles taking in the user inputs via keydown every frame, two option
     *
     * Parameters: none
     *
     * Returns: returns if no interaction is going on
     */
    private void Update()
    {
        
        if (!interact) return;
        if (Input.GetKeyDown("1"))
        {
            //Debug.Log("Choice 1");
            dialogueID = conversations[dialogueID].GetNext(0);
            UIDisable();
            UIDisplay(dialogueID);
        } 
        else if (Input.GetKeyDown("2"))
        {
            //Debug.Log("Choice 2");
            dialogueID = conversations[dialogueID].GetNext(1);
            UIDisplay(dialogueID);
        }
    }
}