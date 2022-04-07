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
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = 1.0f;
        playerScore = 0;

        // Quest items
        questItems = new LinkedList<string>();

        // Miscellaneous items
        miscItems = new LinkedList<string>();
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

    public void AddQuestItem(string questItem)
    {
        questItems.AddLast(questItem);
    }

    public void AddMiscItem(string miscItem)
    {
        miscItems.AddLast(miscItem);
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