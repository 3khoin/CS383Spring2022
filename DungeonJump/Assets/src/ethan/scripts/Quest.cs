using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    public bool questAccept;
    public bool questComplete;
    [SerializeField] private GameObject questBlocker;
    [SerializeField] private GameObject questHazard;
    [SerializeField] private GameObject questItem;

        // Start is called before the first frame update
    void Start()
    {
        quest = true;
        questAccept = false;
        questComplete = false;
    }


    private bool IsComplete()
    {
        return questItem.activeSelf;
    }


    private void GiveQuest()
    {
        questBlocker.SetActive(false);
    }
    
    private void CompleteQuest()
    {
        questHazard.SetActive(false);
    }

    
    void Update()
    {
        if (!interact)
        {
            if (!questAccept)
            {
                questAccept = true;
                GiveQuest();
            }

            if (IsComplete())
            {
                questComplete = true;
                CompleteQuest();
            }
        }
    }
}
