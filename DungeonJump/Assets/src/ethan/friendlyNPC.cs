using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FriendlyNPC : MonoBehaviour
{
    //public FriendlyNPC Friend;
    private int posx;
    private int posy;
    
    //FriendlyNPC friend1 = Instantiate(Friend);

    public void Init(int x, int y)
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(x, y);

        transform.position = pos;
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
