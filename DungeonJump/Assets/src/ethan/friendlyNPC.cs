using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class friendlyNPC : MonoBehaviour
{
    [SerializeField] public GameObject dialogueWindow;
    [SerializeField] private string type;
    // Start is called before the first frame update
    void Start()
    {
        //text = "This is sample text, press enter to leave";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) // help menu
        {
            if (Time.timeScale == 0)
            {
                dialogueWindow.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag != "Player") return; // if not player collision end
        if (type == "liar")
        {
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = "I always tell the truth. Alt+F4 will close the dialogue window.";
        }

        if (type == "truther")
        {
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = "I cannot tell a lie. Press C to close this dialogue window.";
        }
        
        if (type == "default")
        {
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = "No type set.";
        }
        
        Time.timeScale = 0;
        dialogueWindow.SetActive(true);
    }
}
