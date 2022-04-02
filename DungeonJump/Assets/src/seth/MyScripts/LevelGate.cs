/*
 * Filename: LevelGate.cs 
 * Developer: Seth Cram
 * Purpose: File to change scenes upon triggering the GameObject.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: Class to change scenes upon triggering the GameObject.
 * 
 * Member Variables:
 * levelName - String changed externally to specify what scene to change to.
 * lvlMngerInstance - LevelManager used to set the respawn position.
 * soundFX - String set to specify desired sound effect to play.
 */
public class LevelGate : MonoBehaviour
{
    public string levelName = "OverworldSpawnArea";
    //public AnimationClip warpAnim;
    //public AudioSource warpSound;

    public string soundFX = "LevelGate";

    private LevelManager lvlMngerInstance;

    /*
     * Summary: Upon startup, store a reference to the LevelManager singlton.
     * 
     */
    void Start()
    {
        lvlMngerInstance = LevelManager.Instance; //store singlton instance
    }

    /*
     * Summary: When player enters the trigger, player respawn position is saved and the level is changed.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided w/ the player:
        if( collision.gameObject.tag == "Player")
        {

            //store player position for respawn:
            //have to shift y-pos down 1 so don't trigger statue
            lvlMngerInstance.playerRespawnPos = new Vector2( collision.gameObject.transform.position.x, 
                                                             collision.gameObject.transform.position.y - 1); 

            //cosmetic effects:
            Cosmetics();

            //change lvl to platformer lvl:
            //should call after cosmetics are finished
            SwitchLevel(); 
        }
    }


    /*
     * Summary: Changes scene based on lvl name.
     * 
     */
    public void SwitchLevel()
    {
        //change scene to appropriate level by name
        SceneManager.LoadScene(levelName);
    }

    /*
     * Summary: Cosmetic functionality assoc'd with Level Gates.
     *          Currently plays a sound effect if specified.
     * 
     */
    //:
    private void Cosmetics()
    {
        //should play animation

        //if sound effect specified
        if(soundFX != "")
            //should play warp sound
            AudioManager.instance.Play(soundFX);
    }
    
}
