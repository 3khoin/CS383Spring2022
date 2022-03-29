using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileWrapper : MonoBehaviour
{
    [System.Serializable]
    public class DialogueWrapper{
        public Dialog[] dialog;
    }
    
    
    public Dialog[] ReadFile(TextAsset fileName) {
        Debug.Log("ReadJson");
        DialogueWrapper wrap = JsonUtility.FromJson<DialogueWrapper>(fileName.text);
        return wrap.dialog;
    }
}
