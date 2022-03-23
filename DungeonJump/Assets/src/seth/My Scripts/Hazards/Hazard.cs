using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazard : MonoBehaviour
{
    public AudioSource hazardSound;
    
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        print("hazard trigger entered");
    }

    virtual public void OnTriggerExit2D(Collider2D collision)
    {
        print("hazard trigger exited");
    }

}
