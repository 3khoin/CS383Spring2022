/*
 * Filename: PlayerDialogueThree.cs
 * Developer: Ethan
 * Purpose: Subclass of Dialogue
 */


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


/*
 * Summary: This class is the subclass for dialogue that allows three dialogue options for users (1 is exit dialogue, 2 and 3 advances the dialogue).
 *          This class also handles checks for if quests have been completed.
 *
 * Member Variables:
 * questItem - serialized field of what quest item should the dialogue options look for
 */
public class PlayerDialogueThree : Dialogue
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
        //Debug.Log("Dialogue Three Display");
        npcUI.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetNPCText();
        playerUI1.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetFirstText();
        playerUI2.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetSecondText();
        playerUI3.GetComponentInChildren<TextMeshProUGUI>().text = conversations[id].GetThirdText();
    }

    
    /*
     * Summary: override that enables the ui window with three dialogue options
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIEnable()
    {
        //Debug.Log("Three UI Enable");
        npcUI.SetActive(true);
        playerUI1.SetActive(true);
        playerUI2.SetActive(true);
        playerUI3.SetActive(true);
    }

    
    /*
     * Summary: override that disables the ui window with three dialogue options
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected override void UIDisable()
    {
        //Debug.Log("Three UI Disable");
        npcUI.SetActive(false);
        playerUI1.SetActive(false);
        playerUI2.SetActive(false);
        playerUI3.SetActive(false);
    }


    /*
     * Summary: This function checks the world environment to see if the quest item has been collected by the player
     *
     * Parameters: none
     *
     * Returns: none
     */
    private void CheckEnv()
    {
        if (PlayerManagerTmp.instance.QuestItemIsCollected(questItem) && !questEnd)
        {
            Debug.Log("Quest complete Dialogue");
            dialogueID = 2;
        }
        /*if (PlayerManagerTmp.instance.QuestItemIsCollected(questItem) && questEnd && dialogueID != 7)
        {
            Debug.Log("Quest complete Dialogue");
            dialogueID = 3;
        }*/
        UIDisplay(dialogueID);
    }
    
    
    /*
     * Summary: Update handles taking in the user inputs via keydown every frame, three options with a check for if quests are complete.
     *          When the quest end trigger is set true via the dialogue, the quest blocker is removed.
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
            //Debug.Log("Choice 1");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(0);
            else LevelManager.Instance.RemoveProgressBlocks();
            
            //if (!questStart) questStart = conversations[dialogueID].CheckQuest(0);
            dialogueID = conversations[dialogueID].GetNext(0);
            
            UIDisable();
            UIDisplay(dialogueID);
        } 
        else if (Input.GetKeyDown("2"))
        {
            //Debug.Log("Choice 2");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(1);
            else LevelManager.Instance.RemoveProgressBlocks();

            //if (!questStart) questStart = conversations[dialogueID].CheckQuest(1);
            dialogueID = conversations[dialogueID].GetNext(1);
            
            UIDisplay(dialogueID);
        }
        else if (Input.GetKeyDown("3"))
        {
            //Debug.Log("Choice 3");
            if (!questEnd) questEnd = conversations[dialogueID].CheckComplete(2);
            else LevelManager.Instance.RemoveProgressBlocks();
            
            //if (!questStart) questStart = conversations[dialogueID].CheckQuest(2);
            dialogueID = conversations[dialogueID].GetNext(2);
            
            UIDisplay(dialogueID);
        }
    }
}