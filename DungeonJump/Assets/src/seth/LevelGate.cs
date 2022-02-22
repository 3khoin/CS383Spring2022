using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : MonoBehaviour
{
    public int level_Index = 0;
    public AnimationClip warpAnim;
    public AudioSource warpSound;

    // Start is called before the first frame update
    void Start()
    {

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
            StorePlayerPos();

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
        SceneManager.LoadScene( level_Index );
    }

    private void StorePlayerPos()
    {
        //store player pos in LevelManager
    }

    //cosmetic functionality assoc'd with Level Gates:
    private void Cosmetics()
    {
        //should play animation

        //should play warp sound
    }
}
