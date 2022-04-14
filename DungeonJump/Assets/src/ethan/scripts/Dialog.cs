/*
 * Filename: Dialog.cs
 * Developer: Ethan
 * Purpose: Class for dialog variables
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Summary: This class is the subclass for dialogue that allows three dialogue options for users (1 is exit dialogue, 2 and 3 advances the dialogue).
 *          This class also handles checks for if quests have been completed.
 *
 * Member Variables:
 * npcText - the string containing the text for the npc speech to the player
 * firstText - the string for the player response if dialog box 1
 * secondText - the string for the player response if dialog box 2
 * thirdText - the string for the player response if dialog box 3
 * next - an array of integers corresponding to the next dialog options
 * isQuest - an array of booleans determining if the chosen dialog option triggers a quest
 * isComplete - an array of booleans determining if the chosen dialog option ends a quest
 */
[System.Serializable]
public class Dialog
{
    //these variables are case sensitive and must match the strings "firstText" etc. in the JSON
    public string npcText;
    public string firstText;
    public string secondText;
    public string thirdText;
    public int[] next;
    public bool[] isQuest;
    public bool[] isComplete;

    
    /*
     * Summary: fetches the text for the NPC string from the json
     *
     * Parameters: none
     *
     * Returns: string of npcText
     */
    public string GetNPCText() {
        return npcText;
    }
    
    
    /*
     * Summary: fetches the text for the player response 1 string from the json
     *
     * Parameters: none
     *
     * Returns: string of firstText
     */
    public string GetFirstText() {
        return firstText;
    }
    
    
    /*
     * Summary: fetches the text for the player response 2 string from the json
     *
     * Parameters: none
     *
     * Returns: string of secondText
     */
    public string GetSecondText() {
        return secondText;
    }
    
    
    /*
     * Summary: fetches the text for the player response 3 string from the json
     *
     * Parameters: none
     *
     * Returns: string of thirdText
     */
    public string GetThirdText() {
        return thirdText;
    }
    
    
    /*
     * Summary: fetches the dialogueID of the current input from the next array
     *
     * Parameters: the x value wanted from the array
     *
     * Returns: int of the dialogueID
     */
    public int GetNext(int x)
    {
        return next[x];
    }
    
    
    /*
     * Summary: checks if the dialogue option chosen is a quest dialogue from the current input from the isQuest array
     *
     * Parameters: the x value wanted from the array
     *
     * Returns: bool of the isQuest array
     */
    public bool CheckQuest(int x)
    {
        return isQuest[x];
    }
    
    
    /*
     * Summary: checks if the dialogue option chosen is a end quest dialogue from the current input from the isComplete array
     *
     * Parameters: the x value wanted from the array
     *
     * Returns: bool of the isComplete array
     */
    public bool CheckComplete(int x)
    {
        return isComplete[x];
    }
}
