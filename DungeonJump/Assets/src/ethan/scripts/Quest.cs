using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : FriendlyNPC
{
    public bool questAccept;
    public bool questComplete;
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
        if (questItem.activeSelf == true) return false;
        else return false;
    }


    private void CompleteQuest()
    {
        questHazard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
