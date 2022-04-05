using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
        LevelInit();
    }

    void OnSceneLoaded()
    {
        LevelInit(); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWithinBounds();
    }

    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<AudioListener>() == null)
        {
            player.AddComponent<AudioListener>();
        }
    }


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
