/*
 * Filename:JSONReader.cs
 * Developer: Ethan
 * Purpose: Reads .json files
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Summary: This class acts as a singleton that manages the ui elements for FriendlyNPC
 *
 * Member Variables: none
 */
public class JSONReader : MonoBehaviour
{
    [System.Serializable]
    public class Dialogs
    {
        //dialogs is case sensitive and must match the string "dialogs" in the JSON.
        public Dialog[] dialogs;
    }


    public Dialog[] ReadJSON(TextAsset file)
    {
        //Debug.Log("Reading JSON");
        Dialogs wrap = JsonUtility.FromJson<Dialogs>(file.text);
        return wrap.dialogs;
    }
    /*void Start()
    {
        conversations = ReadJSON(jsonFile);
 
        /*foreach (Dialog dialog in conversations)
        {
            Debug.Log("Found " + dialog.firstText + " " + dialog.secondText + " " + dialog.thirdText);
        }
        Debug.Log("Found " + conversations[0].firstText + " " + conversations[0].secondText + " " + conversations[0].thirdText + conversations[0].next[0]);
        Debug.Log("Found " + conversations[1].firstText + " " + conversations[1].secondText + " " + conversations[1].thirdText + conversations[1].next[1]);
        Debug.Log("Found " + conversations[2].firstText + " " + conversations[2].secondText + " " + conversations[2].thirdText + conversations[2].next[2]);
        Debug.Log("Found " + conversations[3].firstText + " " + conversations[3].secondText + " " + conversations[3].thirdText + conversations[3].next[0]);
        Debug.Log(conversations[3].GetThirdText());
    }*/
}
