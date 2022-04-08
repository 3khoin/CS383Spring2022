/* ExitTrigger Prefab
 * name: ExitTrigger
 * summary: Activates cieling and pauses music when gameobject tagged "Player" exits trigger.
 * description: The cieling field must be filled externally to work properly.
 *              Intended to be used in conjunction with "EntrywayEnter" prefab.
 */

/*
 * Filename: EntrywayExit.cs 
 * Developer: Seth Cram 
 * Purpose: File sets cieling to invisible when player exits this GameObject's trigger. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class sets cieling to invisible when player exits this GameObject's trigger.
 * 
 * Member Variables:
 * cieling - GameObject set externally to allow inactiveating of cieling.
 * buildingMusic - AudioSource holding music to Pause.
 */
public class EntrywayExit : MonoBehaviour
{
    public GameObject cieling;
    public AudioSource buildingMusic;

    /*
     * Summary: Turns cieling invisible and pauses music when player exits trigger.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //set cieling visible:
            SetCieling();

            PauseMusic();
        }
    }

    /*
     * Summary: Turns cieling visible.
     * 
     * 
     */
    private void SetCieling()
    {
        cieling.SetActive(true);
    }


    /*
     * Summary: Function to pause any music avaliable..
     * 
     */
    public void PauseMusic()
    {
        //if building music held:
        if (buildingMusic != null)
        {
            //pause it:
            buildingMusic.Pause();
        }
    }
}
