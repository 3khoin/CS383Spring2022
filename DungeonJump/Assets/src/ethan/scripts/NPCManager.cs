/*
 * Filename: NPCManager.cs
 * Developer: Ethan
 * Purpose: Manage UI elements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Summary: This class acts as a singleton that manages the ui elements for FriendlyNPC
 *
 * Member Variables:
 * npcUI - UI box housing NPC text
 * playerUI1 - UI box housing player response 1
 * playerUI2 - UI box housing player response 2
 * playerUI3 - UI box housing player response 3
 * progBlocks - array of progress blockers on the level
 * JR - variable referring to the JSON reader script
 */
public class NPCManager : MonoBehaviour
{
    public static GameObject npcUI;
    public static GameObject playerUI1;
    public static GameObject playerUI2;
    public static GameObject playerUI3;
    public static GameObject[] progBlocks;
    public static JSONReader JR;
    
    public static NPCManager NPCM;
    
    
    /*
     * Summary: on the first time the script is loaded, set the UI elements and progress blockers to their variables
     *
     * Parameters: none
     *
     * Returns: none
     */
    private void Awake()
    {
        Debug.Log("awaken");

        if (NPCM != null) NPCM = this;
        else Destroy(this);        

        npcUI = FindObjectOfType<Canvas>().transform.Find("NPCWindow").gameObject;
        playerUI1 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(1)").gameObject;
        playerUI2 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(2)").gameObject;
        playerUI3 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(3)").gameObject;
        JR = FindObjectOfType<JSONReader>();
        progBlocks = GameObject.FindGameObjectsWithTag("ProgBlock");
        if (progBlocks.Length == 0) Debug.Log("No prog blocks");
        else Debug.Log("Prog Blockers" + progBlocks[0]);
    }
    
}
