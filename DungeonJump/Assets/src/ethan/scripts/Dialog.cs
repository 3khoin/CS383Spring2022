using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    //these variables are case sensitive and must match the strings "firstText" etc. in the JSON
    public string npcText;
    public string firstText;
    public string secondText;
    public string thirdText;
    public int[] next;
    public bool[] isQuest;

    
    public string GetNPCText() {
        return npcText;
    }
    
    
    public string GetFirstText() {
        return firstText;
    }
    
    
    public string GetSecondText() {
        return secondText;
    }
    
    
    public string GetThirdText() {
        return thirdText;
    }
    
    
    public int GetNext(int x)
    {
        return next[x];
    }
    
    
    public bool CheckQuest(int x)
    {
        return isQuest[x];
    }
}
