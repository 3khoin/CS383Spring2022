/*
 * Filename: EntrywayEnter.cs 
 * Developer: Seth Cram 
 * Purpose: File sets cieling to visible when player exits this GameObject's trigger. 
 * 
 */

using UnityEngine;

/*
 * Summary: Class sets cieling to visible and plays music when player exits this GameObject's trigger.
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
     * Summary: Turns cieling visible when player exits trigger.
     *          Also plays/resumes any music avaliable.
     * 
     * Paramters:
     * collision - Collider2D used to determine what triggered this GameObject. 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            cieling.SetActive(false);
        }

        //if building music held  + not playing:
        if ( buildingMusic != null && buildingMusic.isPlaying == false)
        {
            //play/resume it:
            buildingMusic.Play();
        }
    }
}
