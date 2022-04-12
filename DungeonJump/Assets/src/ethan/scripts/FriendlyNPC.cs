/*
 * Filename: FriendlyNPC.cs
 * Developer: Ethan
 * Purpose: Superclass of the friendly NPCs
 */


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;


/*
 * Summary: This class acts as the superclass for the friendly NPCs, housing the functions for player/npc interaction
 *
 * Member Variables:
 * interact - a boolean for if the npc is currently being interacted with
 * questStart - a boolean for if the player has triggered the start of a quest/event
 * questEnd - a boolean for if the player has triggered the end of a quest/event
 */
public class FriendlyNPC : MonoBehaviour
{
    protected bool interact;
    protected bool questStart;
    protected bool questEnd;

    
    /*
     * Summary: sets starting variable values
     *
     * Parameters: none
     *
     * Returns: none
     */
    private void Start()
    {
        interact = false;
        questStart = false;
        questEnd = false;
    }

    
    /*
     * Summary: spawns new NPC prototypes
     *
     * Parameters:
     * x - x position on the plane
     * y - y position on the plane
     *
     * Returns: none
     */
    public void Init(int x, int y)
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(x, y);

        transform.position = pos;
    }

    
    /*
     * Summary: virtual that activates code when a player touches the friendly NPC collider
     *
     * Parameters:
     * col - object that collided with the npc
     *
     * Returns: none
     */
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter " + col.gameObject.tag);
    }
    
    
    /*
     * Summary: virtual that activates code when a player leaves the friendly NPC collider
     *
     * Parameters:
     * col - object that collided with the npc
     *
     * Returns: none
     */
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit " + col.gameObject.tag);
    }
}