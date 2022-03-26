using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FriendlyNPC : MonoBehaviour
{
    protected bool interact;

    void Start()
    {
        interact = false;
    }

    public void Init(int x, int y)
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(x, y);

        transform.position = pos;
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        interact = true;
        Debug.Log("Enter " + col.gameObject.tag);
    }
    
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        interact = false;
        Debug.Log("Exit " + col.gameObject.tag);
    }
}