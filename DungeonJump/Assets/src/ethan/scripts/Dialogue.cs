/*
 * Filename: Dialogue.cs
 * Developer: Ethan
 * Purpose: Subclass of FriendlyNPC
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;


/*
 * Summary: This class acts as the subclass for the friendly NPCs that handles dialogue with the player
 *
 * Member Variables:
 * blocker - the progress blocker on a level
 * npcUI - UI box housing NPC text
 * playerUI1 - UI box housing player response 1
 * playerUI2 - UI box housing player response 2
 * playerUI3 -UI box housing player response 3
 * dialogueID - current ID for the player/npc interaction
 * jsonFile - serialized field for the external text file with the dialogue
 * conversations - array of dialogs for the NPC
 */
public class Dialogue : FriendlyNPC
{
    protected GameObject blocker;
    protected GameObject npcUI;
    protected GameObject playerUI1;
    protected GameObject playerUI2;
    protected GameObject playerUI3;
    protected int dialogueID;
    [SerializeReference] public TextAsset jsonFile;
    public Dialog[] conversations;


    /*
     * Summary: sets starting variable values
     *
     * Parameters: none
     *
     * Returns: none
     */
    private void Start()
    {
        npcUI = NPCManager.npcUI;
        playerUI1 = NPCManager.playerUI1;
        playerUI2 = NPCManager.playerUI2;
        playerUI3 = NPCManager.playerUI3;
        dialogueID = 0;
        conversations = NPCManager.JR.ReadJSON(jsonFile);
        if (NPCManager.progBlocks.Length != 0) blocker = NPCManager.progBlocks[0];
        else blocker = null;
    }
    
    
    /*
     * Summary: virtual that displays the text of the conversation
     *
     * Parameters: the current id of the dialogue
     *
     * Returns: none
     */
    protected virtual void UIDisplay(int id)
    {
        Debug.Log("Default Player Display");
    }

    
    /*
     * Summary: virtual that enables the ui
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected virtual void UIEnable()
    {
        Debug.Log("Default UI Enable");
    }

    
    /*
     * Summary: virtual that disables the ui
     *
     * Parameters: none
     *
     * Returns: none
     */
    protected virtual void UIDisable()
    {
        Debug.Log("Default UI Disable");
    }
    

    /*
     * Summary: override that activates code when a player touches the friendly NPC collider
     *
     * Parameters:
     * col - object that collided with the npc
     *
     * Returns: none
     */
    public override void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = true;
            UIEnable();
            UIDisplay(dialogueID);
        }
    }

    
    /*
     * Summary: override that activates code when a player leaves the friendly NPC collider
     *
     * Parameters:
     * col - object that collided with the npc
     *
     * Returns: none
     */
    public override void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit " + col.gameObject.tag + " for Dialogue");
        if (col.gameObject.CompareTag("Player")) // if player collision end
        {
            interact = false;
            UIDisable();
        }
    }
}