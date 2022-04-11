/*
* Filename: PlatformLevelManager.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the PlatformerLevelManger singleton class which manages the game in platforming levels
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
* Summary: The PlatformLevelManager class which manages the game in platforming levels
*
* Member Variables:
* instance - the singleton
* player - a game object which corresponds to the main player
* cam - the camera object in the scene
* spawnPnt - the spawn point object within the level
* top/bot/left/rightPnt - the boundary points corresponding to their orientation facing the level
*/
public class PlatformLevelManager : MonoBehaviour
{
    public static PlatformLevelManager instance; //singleton
    public GameObject player;
    public GameObject cam;
    private Transform spawnPnt;
    private Transform topPnt;
    private Transform botPnt;
    private Transform leftPnt;
    private Transform rightPnt;


    /*
    * Summary: Initialize a PlatformLevelManager singleton
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
        void Awake()
    {
        // Singleton code
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    /*
    * Summary: Run level initialization
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void Start()
    {
        LevelInit();
    }


/*
    * Summary: Run level initialization
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void OnSceneLoaded()
    {
        LevelInit(); 
    }


    /*
    * Summary: Check that the player remains in bounds every frame update
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void Update()
    {
        PlayerWithinBounds();
    }


    /*
    * Summary: Initialize an AudioManager singleton
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<AudioListener>() == null)
        {
            player.AddComponent<AudioListener>();
        }
    }

    /*
    * Summary: Checks to ensure the player is within the level bounds
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void PlayerWithinBounds (){
        player = GameObject.FindGameObjectWithTag("Player");
        if (leftPnt != null && rightPnt != null && topPnt != null && botPnt != null)
        {
            if (leftPnt.position.x >    player.transform.position.x){
                Debug.Log("Player exceeded level boundary: " + leftPnt.transform.position);
                //tele player to spawn
                player.transform.position = spawnPnt.position;
                Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
            }
            else if (rightPnt.position.x < player.transform.position.x){
                Debug.Log("Player exceeded level boundary: " + rightPnt.transform.position);
                player.transform.position = spawnPnt.position;
                Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
            }
            else if (topPnt.position.y <   player.transform.position.y){
                Debug.Log("Player exceeded level boundary: " + topPnt.transform.position);
                player.transform.position = spawnPnt.position;
                Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
            }
            else if (botPnt.position.y >   player.transform.position.y){
                Debug.Log("Player exceeded level boundary: " + botPnt.transform.position);
                player.transform.position = spawnPnt.position;
                Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
            }
        }
    }

    /*
    * Summary: Initialize a platform level by grabbing all of the boundary points and spawn placed in the scene
    * sets the player's position to the spawn point and sets up the camera
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
    void LevelInit(){
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPnt = GameObject.FindGameObjectWithTag("Spawn").transform;
        
        topPnt = GameObject.FindGameObjectWithTag("top").transform;
        botPnt = GameObject.FindGameObjectWithTag("bot").transform;
        leftPnt = GameObject.FindGameObjectWithTag("left").transform;
        rightPnt = GameObject.FindGameObjectWithTag("right").transform;

        // check if the player has an audio listener attached and add one if not
        //if (player.GetComponent<AudioListener>() == null)
        //{
            player.AddComponent<AudioListener>();
        //}

        // find the player and set the position to the spawn point
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnPnt.position;

        // find the camera and center it to the player
        cam  = GameObject.FindGameObjectWithTag("MainCamera");
        cam.transform.position = player.transform.position + new Vector3 (0f, 0f, -10f);
    }
}
