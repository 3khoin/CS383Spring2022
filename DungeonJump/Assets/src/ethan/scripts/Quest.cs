using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    [SerializeField] private int questItem;

    
    // Start is called before the first frame update
    private void Start()
    {
        //questComplete = false;
    }


    private bool IsComplete()
    {
        if (questItem == 1)
        {
            return true;
        } 
        return false;
    }


    private void Update()
    {
        if (interact)
        {
            if (questStart)
            {
                if (IsComplete())
                {
                    dialogueID = 3;
                    questStart = false;
                }
            }

            if (questEnd)
            {
                LevelManager.Instance.RemoveProgressBlocks();
            }
        }
    }
}
