using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FriendlyNPC : MonoBehaviour
{
    protected bool interact;
    protected bool helpful;
    protected bool harmful;
    
    
    void Start()
    {
        interact = false;
        helpful = false;
        harmful = false;
    }

    public void Init(int x, int y)
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(x, y);

        transform.position = pos;
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enter " + col.gameObject.tag);
    }
    
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit " + col.gameObject.tag);
    }
}