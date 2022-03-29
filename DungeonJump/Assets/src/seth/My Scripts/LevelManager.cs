/*
 * Filename: LevelManager.cs 
 * Developer: Seth Cram
 * Purpose: File to manage the overworld levels and keep track of specific world attributes.
 */

using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Singleton class to manage the overworld levels and keep track of specific world attributes .
 * 
 * Member Variables:
 * progressBlocks - GameObject array filled with the current scene's progress blocks.
 * playerRespawnPos - Vector2 that should be used to repawn the player with.
 * score - float to keep track of total game score.
 * playerCurrItems - GameObject list to hold all of the player's items.
 * totItems -int keeping track of total items in the game.
 * progPercentage - float to track progress. 
 * instance - SINGLETON: (static obj, Instance def, and awake) (persistent across scenes, doesn't need attachment to gameobj, created w/ needed)
 */
public class LevelManager : MonoBehaviour
{
    public GameObject[] progressBlocks;
    //public GameObject player;
    public Vector2 playerRespawnPos;

    public float score;

    //need to be filled by outside scripts as items found:
    public List<GameObject> playerCurrItems = new List<GameObject>(); 
    private int totItems = 10; 

    //private int progZone = 1;
    public float progPercentage;

    private static LevelManager instance = null;

    /*
     * Summary: Singleton definition of LevelManager instance. Persistent across scenes and used by other classes.
     *          Created when needed.
     * 
     */
    public static LevelManager Instance 
    {
        get
        {
            if (instance == null)
            {
                //find instance in scene
                instance = FindObjectOfType<LevelManager>();

                //if no instance in scene
                if (instance == null) 
                {
                    //create new manager in scene:
                    GameObject mnger = new GameObject();
                    mnger.name = "LevelManager";
                    instance = mnger.AddComponent<LevelManager>();

                    print("new (level) manager created");

                    //make sure not destroyed w/ change scenes
                    DontDestroyOnLoad(mnger); 
                }
            }
            return instance;
        }
    }

    /*
     * Summary: Makes sure there's only one instance of Singleton LevelManager in scenes.
     * 
     */
    void Awake()
    {
        //instance not here
        if (instance == null) 
        {
            //set instance to this script (triggers above Instance method to create/destroy)
            instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        //instance here
        else
        {
            //destroy it
            Destroy(gameObject); 
        }
    }

    /*
     * Summary: Repeatedly check player's progress and test removing of progress blocks if necessary.
     * 
     */
    void Start()
    {
        //check progress after 10 secs, every 10 secs:
        InvokeRepeating("CheckProgress", 10, 10);

        //test removing current scene's progress blocks:
        InvokeRepeating("RemoveProgressBlocks", 10, 10);
    }

    /*
     * Summary: Update player's progress using number of player items vs total items in game.
     * 
     */
    public void CheckProgress() 
    {
        print("Progress being checked");

        if (playerCurrItems != null)
            //calc progPercentage thru ratio of player items and tot items:
            progPercentage = (playerCurrItems.Count / totItems) * 100;
        else
            progPercentage = 0;

        //if progressed enough for curr zone:
        /*
        if (progPercentage >= 25 && progZone == 1 || 
            progPercentage >= 50 && progZone == 2 ||
            progPercentage >= 75 && progZone == 3)
        {
            RemoveProgressBlocks();

            progZone++; //incr to nxt prog zone
        }
        */
    }

    /*
     * Summary: Remove all of the scene's progress blocks by finding them and setting inactive.
     * 
     */
    public void RemoveProgressBlocks()
    {
        //get all progress blocks in current scene: (need to do everytime they needa be cleared)
        progressBlocks = GameObject.FindGameObjectsWithTag("ProgBlock");

        //no prog blocks found:
        if (progressBlocks == null || progressBlocks.Length == 0)
            Debug.Log("No progress blocks found in current scene.");

        //walk thru all prog blocks:
        for(int i = 0; i < progressBlocks.Length; i++)
        {
            //debugging
            print("removed progress block: " + progressBlocks[i].name);

            //turn off visibility of prog block:
            progressBlocks[i].SetActive(false);
        }
    }
}
