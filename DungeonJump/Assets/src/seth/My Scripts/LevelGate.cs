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
 */
public class LevelGate : MonoBehaviour
{
    public string levelName = "Overworld Spawn Area";
    //public AnimationClip warpAnim;
    //public AudioSource warpSound;

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
            lvlMngerInstance.playerRespawnPos = new Vector2( collision.gameObject.transform.position.x, 
                                                             collision.gameObject.transform.position.y - 1); //have to shift y-pos down 1 so don't trigger statue

            //cosmetic effects:
            //Cosmetics();

            //change lvl to platformer lvl:
            SwitchLevel(); //should call after cosmetics are finished
        }
    }


    /*
     * Summary: Changes scene based on lvl name.
     * 
     */
    public void SwitchLevel()
    {
        //change scene to appropriate lvl+build index
        //SceneManager.LoadScene( level_Index );

        SceneManager.LoadScene(levelName);
    }

    /*
    //cosmetic functionality assoc'd with Level Gates:
    private void Cosmetics()
    {
        //should play animation

        //should play warp sound
    }
    */
}
