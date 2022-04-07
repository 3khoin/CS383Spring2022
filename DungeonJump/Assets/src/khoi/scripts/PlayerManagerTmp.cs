using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerTmp : MonoBehaviour
{
    public static PlayerManagerTmp instance { get; private set; }

    private float playerHealth;
    private int playerScore;
    private LinkedList<string> questItems, miscItems;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        playerHealth = 1.0f;
        playerScore = 0;

        // Quest items
        questItems = new LinkedList<string>();

        // Miscellaneous items
        miscItems = new LinkedList<string>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public void UpdatePlayerHealth(float healthChange)
    {
        playerHealth = playerHealth + healthChange;
        if(playerHealth > 1f) playerHealth = 1f;
        if(playerHealth < 0f) playerHealth = 0f;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void UpdatePlayerScore(int scoreChange)
    {
        playerScore = playerScore + scoreChange;
    }

    public void GetQuestItems()
    {
        Debug.Log("List of quest items:");
        foreach(string str in questItems)
        {
            Debug.Log(str);
        }
    }

    public void GetMiscItems()
    {
        Debug.Log("List of miscellaneous items:");
        foreach(string str in miscItems)
        {
            Debug.Log(str);
        }
    }

    public void AddQuestItem(string questItem)
    {
        questItems.AddLast(questItem);
        GetQuestItems();
    }

    public void AddMiscItem(string miscItem)
    {
        miscItems.AddLast(miscItem);
        GetMiscItems();
    }

    public bool QuestItemIsCollected(string questItem)
    {
        return questItems.Contains(questItem);
    }

    public bool MiscItemIsCollected(string miscItem)
    {
        return miscItems.Contains(miscItem);
    }
}