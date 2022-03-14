using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : MonoBehaviour
{
    //public int level_Index = 0;
    public string level_name = "Overworld Spawn Area";
    public AnimationClip warpAnim;
    public AudioSource warpSound;

    private LevelManager lvlMngerInstance;

    // Start is called before the first frame update
    void Start()
    {
        lvlMngerInstance = LevelManager.Instance; //store singlton instance
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided w/ the player:
        if( collision.gameObject.tag == "Player")
        {
            //store player position for respawn:
            lvlMngerInstance.playerRespawnPos = new Vector2( collision.gameObject.transform.position.x, 
                                                             collision.gameObject.transform.position.y - 1); //have to shift y-pos down 1 so don't trigger statue

            //cosmetic effects:
            Cosmetics();

            //change lvl to platformer lvl:
            SwitchLevel(); //should call after cosmetics are finished
        }
    }

    //changes scene based on lvl index:
    public void SwitchLevel()
    {
        //change scene to appropriate lvl+build index
        //SceneManager.LoadScene( level_Index );

        SceneManager.LoadScene(level_name);
    }

    //cosmetic functionality assoc'd with Level Gates:
    private void Cosmetics()
    {
        //should play animation

        //should play warp sound
    }
}
