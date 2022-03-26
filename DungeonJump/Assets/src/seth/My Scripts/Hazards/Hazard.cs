using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazard : MonoBehaviour
{
    public AudioSource hazardSound;
    
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            print("hazard triggered by player entering");    
    }

    virtual public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            print("hazard triggered by player exiting");
    }

}
