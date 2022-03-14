using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] progressBlocks;
    //public GameObject player;
    public Vector2 playerRespawnPos;

    //need to be filled by outside scripts as items found:
    public GameObject[] playerCurrItems;     //public int currItems;
    private int totItems = 10; //10 has no meaning

    private int progZone = 1;
    private float progPercentage;

    //SINGLETON: (static obj, Instance def, and awake) (persistent across scenes, doesn't need attachment to gameobj, created w/ needed)
    private static LevelManager instance = null;
    public static LevelManager Instance //definition of an Instance used by other classes
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>(); //find instance in scene

                if (instance == null) //if no instance in scene
                {
                    //create new manager in scene:
                    GameObject mnger = new GameObject();
                    mnger.name = "LevelManager";
                    instance = mnger.AddComponent<LevelManager>();

                    print("new manager created");

                    DontDestroyOnLoad(mnger); //make sure not destroyed w/ change scenes
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null) //instance not here
        {
            instance = this; //set instance to this script (triggers above Instance method to create/destroy)
            DontDestroyOnLoad(this.gameObject);
        }
        else //instance here
        {
            Destroy(gameObject); //destroy it
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //check progress after 10 secs, every 10 secs:
        InvokeRepeating("CheckProgress", 10, 10);

        //test removing the first blocks:
        Remove_PBlocks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckProgress() 
    {
        print("Prog being checked");

        if (playerCurrItems != null)
            //calc progPercentage thru ratio of player items and tot items:
            progPercentage = (playerCurrItems.Length / totItems) * 100;
        else
            progPercentage = 0;

        //if progressed enough for curr zone:
        if (progPercentage >= 25 && progZone == 1 || 
            progPercentage >= 50 && progZone == 2 ||
            progPercentage >= 75 && progZone == 3)
        {
            Remove_PBlocks();

            progZone++; //incr to nxt prog zone
        }
    }

    //remove specified prog block:
    private void Remove_PBlocks()
    {
        //get all progress blocks in current scene: (need to do everytime they needa be cleared)
        progressBlocks = GameObject.FindGameObjectsWithTag("ProgBlock");

        //no prog blocks found:
        if (progressBlocks == null)
            Debug.Log("No progress blocks found in current scene.");

        print("found progress block: " + progressBlocks[0].name); //debugging

        //walk thru all prog blocks:
        for(int i = 0; i < progressBlocks.Length; i++)
        {
            //turn off visibility of prog block:
            progressBlocks[i].SetActive(false);
        }
    }
}
