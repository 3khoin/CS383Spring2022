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
 * Member Variables:
 * questItem - serialized field of what quest item should the dialogue options look for
 */
public class PlayerDialogueOne : Dialogue
{
    [SerializeField] protected string questItem;
    
    
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
     * Summary: Gets the next dialog item and displays it based on an input i. If the next dialog triggers the end of a
     *          quest, the world blocker is removed.
     *
     * Parameters:
     * i - the index of the dialog arrays you wish to fetch
     *
     * Returns: none
     */
    private void NextDialogue(int i)
    {
        questEnd = conversations[dialogueID].CheckComplete(i);
        if (questEnd) LevelManager.Instance.RemoveProgressBlocks();

        dialogueID = conversations[dialogueID].GetNext(i);
            
        UIDisplay(dialogueID);
    }
    
    
    /*
     * Summary: This function checks the world environment to see if certain conditions are met and updates the dialogue
     *          accordingly.
     *
     * Parameters: none
     *
     * Returns: none
     */
    private void CheckEnv()
    {
        // when the quest item is got and the ending dialogue has not been triggered
        if (PlayerManagerTmp.instance.QuestItemIsCollected(questItem) && !questEnd)
        {
            Debug.Log("Quest complete Dialogue");
            dialogueID = 2;
        }

        // when player backtracks, resets dialogue to final dialogue
        if (blocker != null)
        {
            if (blocker.activeSelf == false && dialogueID == 2)
            {
                Debug.Log("Quest complete Dialogue");
                dialogueID = 3;
            }
        }
        UIDisplay(dialogueID);
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
        CheckEnv();
        if (Input.GetKeyDown("1"))
        {
            NextDialogue(0);
            UIDisable();
        }
    }
}
