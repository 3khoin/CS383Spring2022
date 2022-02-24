using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entryway : MonoBehaviour
{
    public AnimationClip openAnim;
    public AnimationClip closeAnim;
    public AudioSource interactSound;
    public bool playerEntered = false;

    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvertEntryway() //should be called by player w/ interact w/ entryway
    {
        if( open )
        {
            //close entryway

            open = false;
        }
        else
        {
            //open entryway
            

            open = true;
        }
    }
}
