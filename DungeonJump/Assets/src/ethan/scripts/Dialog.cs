using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialog : MonoBehaviour
{
    [SerializeField] public string npcText;
    [SerializeField] public string pOneText;
    [SerializeField] public string pTwoText;
    [SerializeField] public string pThreeText;
    [SerializeField] public int[] next;
    [SerializeField] public bool[] quest;
    /*
    
    public string GetNPCText() {
        return npcText;
    }
    
    
    public void SetNPCText(string s) {
        npcText = s;
    }
    
    
    public string GetPOneText() {
        return pOneText;
    }
    
    
    public void SetPOneText(string s) {
        pOneText = s;
    }
    
    
    public string GetPTwoText() {
        return pTwoText;
    }
    
    
    public void SetPTwoText(string s) {
        pTwoText = s;
    }
    
    
    public string GetPThreeText() {
        return pThreeText;
    }
    
    
    public void SetPThreeText(string s) {
        pThreeText = s;
    }
    
    
    public int GetNext(int i) {
        return next[i];
    }
    
    
    public void SetNext(int x, int y, int z) {
        next = new int[]{x, y, z};
    }
    
    
    public bool GetQuest(int i) {
        return quest[i];
    }
    
    
    public void SetQuest(bool x, bool y, bool z) {
        quest = new bool[]{x, y, z};
    }*/
}
