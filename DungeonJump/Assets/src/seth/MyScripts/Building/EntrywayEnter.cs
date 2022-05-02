/* EntryTrigger Prefab
 * name: EntryTrigger
 * summary: Inactivates cieling and plays music when gameobject tagged "Player" exits trigger.
 * description: A trigger that plays music if there's music specified. 
 *              The cieling field must be filled externally to work properly.
 *              Intended to be used in conjunction with "EntrywayExit" prefab.
 *      
 * 
 */

/*
 * Filename: EntrywayEnter.cs 
 * Developer: Seth Cram 
 * Purpose: File sets cieling to invisible when player exits this GameObject's trigger. 
 * Notes:
 *      My use of building music falls under fair use because:
 *          Purpose and character of my use is radically different. I use it as a celebratory tune
 *              in an incredibly small area.
 *          No effect of my use of copyrighted work upon the Runescape market.
 *              Even if publish game for commercial use, game genre wildly different.
 */

using UnityEngine;

/*
 * Summary: Class sets cieling to invisible and plays music when player exits this GameObject's trigger.
 * 
 * Member Variables:
 * cieling - GameObject set externally to allow activeating of cieling.
 * buildingMusic - AudioSource holding music to play.
 */
public class EntrywayEnter : MonoBehaviour
{
    public GameObject cieling;
    public AudioSource buildingMusic;

    /*
     * Summary: Turns cieling invisible when player exits trigger.
     *          Also plays/resumes any music avaliable.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ClearCieling();

            PlayMusic();
        }
    }

    /*
     * Summary: Turns cieling invisible.
     * 
     * 
     */
    private void ClearCieling()
    {
        cieling.SetActive(false);
    }

    /*
     * Summary: Function to play/resume any music avaliable..
     * 
     */
    public void PlayMusic()
    {
        //if building music held  + not playing:
        if (buildingMusic != null && buildingMusic.isPlaying == false)
        {
            //play/resume it:
            buildingMusic.Play();
        }
    }
}
