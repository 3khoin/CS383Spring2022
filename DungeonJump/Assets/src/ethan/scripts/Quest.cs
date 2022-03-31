using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    public bool questComplete;
    public string bane;
    [SerializeField] private GameObject questItem;

    
    // Start is called before the first frame update
    private void Start()
    {
        questComplete = false;
    }


    private bool IsComplete()
    {
        return questItem.activeSelf;
    }


    private void GiveBane()
    {
        
    }


    private void Update()
    {
        if (interact)
        {
            // this checks if the quest parameters are complete, and calls level manager to remove blockage
            if (IsComplete() && helpful)
            {
                questComplete = true;
                LevelManager.Instance.RemoveProgressBlocks();
            }

            if (harmful)
            {
                //MainPlayer.moveSpeed;
            }
        }
    }
}
