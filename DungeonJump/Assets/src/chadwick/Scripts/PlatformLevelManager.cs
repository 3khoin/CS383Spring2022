using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
       PlayerWithinBounds();
    }


    void PlayerWithinBounds (){
        player = GameObject.FindGameObjectWithTag("Player");
        if (leftPnt.position.x >    player.transform.position.x){
            Debug.Log("Player exceeded level boundary: " + leftPnt.transform.position);
            //tele player to spawn
            player.transform.position = spawnPnt.position;
            Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
        }
        else if (rightPnt.position.x < player.transform.position.x){
            Debug.Log("Player exceeded level boundary: " + rightPnt.transform.position);
            //tele player to spawn
            player.transform.position = spawnPnt.position;
            Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
        }
        else if (topPnt.position.y <   player.transform.position.y){
            Debug.Log("Player exceeded level boundary: " + topPnt.transform.position);
            //tele player to spawn
            player.transform.position = spawnPnt.position;
            Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
        }
        else if (botPnt.position.y >   player.transform.position.y){
            Debug.Log("Player exceeded level boundary: " + botPnt.transform.position);
            //tele player to spawn
            player.transform.position = spawnPnt.position;
            Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
        }
    }

    void LevelInit(){
        spawnPnt = GameObject.FindGameObjectWithTag("Spawn").transform;
        
        topPnt = GameObject.FindGameObjectWithTag("top").transform;
        botPnt = GameObject.FindGameObjectWithTag("bot").transform;
        leftPnt = GameObject.FindGameObjectWithTag("left").transform;
        rightPnt = GameObject.FindGameObjectWithTag("right").transform;
        
        player.AddComponent<AudioListener>();

        // find the player and set the position to the spawn point
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnPnt.position;
        //player.GetComponent<Script>();

        // find the camera and center it to the player
        cam  = GameObject.FindGameObjectWithTag("MainCamera");
        //Vector3 camPos = cam.GetComponent<Transform>().position;
        cam.transform.position = player.transform.position + new Vector3 (0f, 0f, -10f);
        //Debug.Log("Cam position should be changed");
    }
}
