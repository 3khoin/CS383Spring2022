using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    [SerializeField] private string item;

    
    private bool IsComplete()
    {
        return PlayerManagerTmp.instance.QuestItemIsCollected(item);
    }


    private void Update()
    {
        if (interact)
        {
            if (questStart && IsComplete())
            { 
                dialogueID = 3;
                questStart = false;
            }

            if (questEnd)
            {
                LevelManager.Instance.RemoveProgressBlocks();
            }
        }
    }
}
