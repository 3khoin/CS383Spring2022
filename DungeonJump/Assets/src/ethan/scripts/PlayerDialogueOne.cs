/*
 * Filename: PlayerDialogueOne.cs
 * Developer: Ethan
 * Purpose: Subclass of Dialogue
 */


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * Summary: This class is the subclass for dialogue that allows one dialogue option for users (1 is exit dialogue, so only the root of the tree is available)
 *
 * Member Variables: none
 */
public class PlayerDialogueOne : Dialogue
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
        //Debug.Log("Dialogue One Display");
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
    }
    
    
    /*
     * Summary: override that enables the ui window with one dialogue option
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIEnable()
    {
        //Debug.Log("One UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
    }

    
    /*
     * Summary: override that disables the ui window with one dialogue option
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIDisable()
    {
        //Debug.Log("One UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
    }
    
    
    /*
     * Summary: update handles taking in the user inputs via keydown every frame, only one option
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
    }
}
