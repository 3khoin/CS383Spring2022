using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager NPCM;
    public static GameObject NPCUI;
    public static GameObject PlayerUI1;
    public static GameObject PlayerUI2;
    public static GameObject PlayerUI3;
    // Start is called before the first frame update

    [SerializeField] public FriendlyNPC Talking;

    private void Awake()
    {
        Debug.Log("awaken");

        NPCUI = FindObjectOfType<Canvas>().transform.Find("NPCWindow").gameObject;
        PlayerUI1 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(1)").gameObject;
        PlayerUI2 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(2)").gameObject;
        PlayerUI3 = FindObjectOfType<Canvas>().transform.Find("PlayerWindow(3)").gameObject;
    }
    
}
