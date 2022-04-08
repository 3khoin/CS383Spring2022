using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    [SerializeField] private string questItem;


    public bool IsComplete()
    {
        Debug.Log("Check Completed.");
        return PlayerManagerTmp.instance.QuestItemIsCollected(questItem);
    }

    public void ClearBlock()
    {
        Debug.Log("Clear Blocker");
        LevelManager.Instance.RemoveProgressBlocks();
    }
}
