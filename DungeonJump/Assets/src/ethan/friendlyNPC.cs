using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendlyNPC : MonoBehaviour
{

    //protected bool interact;
    // Start is called before the first frame update
    void Start()
    {
        //interact = false;
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter");
        Debug.Log(col.gameObject.tag);
        if (!col.gameObject.CompareTag("Player")) return; // if not player collision end
    }
    
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit");
        Debug.Log(col.gameObject.tag);
        if (!col.gameObject.CompareTag("Player")) return; // if not player collision end
    }
}
