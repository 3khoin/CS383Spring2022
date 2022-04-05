/*
 * Filename: LevelManager.cs 
 * Developer: Seth Cram
 * Purpose: File to manage the overworld levels and keep track of specific world attributes.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: Singleton class to manage the overworld levels and keep track of specific world attributes .
 * 
 * Member Variables:
 * progressBlocks - GameObject array filled with the current scene's progress blocks.
 * playerRespawnPos - Vector2 array that should be used to repawn the player with in each level 0-3.
 * score - float to keep track of total game score.
 * playerCurrItems - GameObject list to hold all of the player's items.
 * totItems -int keeping track of total items in the game.
 * progPercentage - float to track progress. 
 * instance - SINGLETON: (static obj, Instance def, and awake) (persistent across scenes, doesn't need attachment to gameobj, created w/ needed)
 */
public class LevelManager : MonoBehaviour
{
    public GameObject[] progressBlocks;

    public string[] sceneNames = { "OverworldSpawnArea", "OverworldDemoScene", "OverworldAlienScape", "OverworldGrungieArea" };

    public float score;

    //need to be filled by outside scripts as items found:
    public List<GameObject> playerCurrItems = new List<GameObject>(); 
    private int totItems = 10; 

    //private int progZone = 1;
    public float progPercentage;

    //allocate enough space for one respawn per overworld scene:
    private Vector2[] playerRepawnPos = new Vector2[4]; //{ null, null, null, null };

    //make prog blocks visible by default w/ one prog block visiblity setting per overworld scene:
    private bool[] progBlockVisibility = { true, true, true, true };

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

                    print("new (overworld level) manager created");

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

        //subscribe method to spawn player at respawn loc w/ scenes loaded in:
        SceneManager.sceneLoaded += OnSceneLoadedRespawn;

        //sub method to make prog blocks in/visible every scene load:
        SceneManager.sceneLoaded += OnSceneLoadedProgBlocks;
    }

    /*
     * Summary: Method subscribed to SceneLoaded. Everytime enter new scene, if it's 
     *          prog blocks visibility is False, the prog blocks are removed.
     * 
     */
    private void OnSceneLoadedProgBlocks(Scene currScene, LoadSceneMode mode)
    {
        //throw new NotImplementedException();

        //walk thru whole sceneNames arr:
        for (int i = 0; i < sceneNames.Length; i++)
        {
            //if curr scene is found and its respawn is already set: 
            if (currScene.name == sceneNames[i] && progBlockVisibility[i] == false)
            {
                //remove all prog blocks in curr scene:
                RemoveProgressBlocks();
            }
        }
    }

    /*
     * Summary: Method subscribed to SceneLoaded. Everytime enter new scene, if it's 
     *          respawn point is set, the player is moved there.
     * 
     */
    private void OnSceneLoadedRespawn(Scene currScene, LoadSceneMode mode)
    {
        //throw new NotImplementedException();

        //debug:
        //Debug.Log("OnSceneLoaded: " + currScene);
        //Debug.Log("Scene mode: " + mode);

        //walk thru whole sceneNames arr:
        for (int i = 0; i < sceneNames.Length; i++)
        {
            //if curr scene is found and its respawn is already set: (assumes no level gate is near map origin)
            if ( currScene.name == sceneNames[i] && playerRepawnPos[i] != new Vector2(0, 0) )
            {
                //teleport player to desired respawn loc:
                GameObject.FindGameObjectWithTag("Player").GetComponent <Transform>().position 
                    = new Vector3( playerRepawnPos[i].x, playerRepawnPos[i].y, 0);

                print("Player respawned to: " + playerRepawnPos.ToString());
            }
        }
    }

    /*
     * Summary: Update player's progress using number of player items vs total items in game.
     * 
     */
    public void CheckProgress() 
    {
        if (playerCurrItems != null)
            //calc progPercentage thru ratio of player items and tot items:
            progPercentage = (playerCurrItems.Count / totItems) * 100;
        else
            progPercentage = 0;

        print("Player Item collection progress: " + progPercentage);

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
     *          Makes sure their visibility is false for future scene revisits.
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

        //walk thru whole sceneNames arr:
        for (int i = 0; i < sceneNames.Length; i++)
        {
            //if curr scene is found: 
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                //turn prog block visiblity off:
                progBlockVisibility[i] = false;
            }
        }
    }

    /*
     * Summary: Set the appropriate scene's player respawn location.
     * 
     */
    public void SetRespawn( Vector2 respawn2D)
    {
        //walk thru whole sceneNames arr:
        for (int i = 0; i < sceneNames.Length ; i++)
        {
            //if curr scene is found: (hopefully active scene hasn't changed yet)
            if(SceneManager.GetActiveScene().name == sceneNames[i])
            {
                //copy respawn loc into that scene's respawn pos:
                playerRepawnPos[i] = respawn2D; 
            }
        }
    }
}
