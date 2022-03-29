using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static FileWrapper FW;
    public static GameObject npcUI;
    public static GameObject playerUI1;
    public static GameObject playerUI2;
    public static GameObject playerUI3;
    // Start is called before the first frame update

    [SerializeField] public FriendlyNPC Talking;

    private void Awake()
    {
        Debug.Log("awaken");

        npcUI = FindObjectOfType<Canvas>().transform.Find("NPCWindow").gameObject;
        playerUI1 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(1)").gameObject;
        playerUI2 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(2)").gameObject;
        playerUI3 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(3)").gameObject;
        FW = FindObjectOfType<FileWrapper>();
    }
    
}
