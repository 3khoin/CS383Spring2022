/*
 * Filename: PlayerDialogueThree.cs
 * Developer: Ethan
 * Purpose: Subclass of Dialogue
 */


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
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
     * Parameters:
     * id - the current id of the dialogue to display
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
     * Summary: Update handles taking in the user inputs via keydown every frame, three options with a check for if quests are complete.
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
        else if (Input.GetKeyDown("2"))
        {
            NextDialogue(1);
        }
        else if (Input.GetKeyDown("3"))
        {
            NextDialogue(2);
        }
    }
}