using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTrigger : MonoBehaviour
{
    public GameObject cieling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if triggered by player:
        if( collision.gameObject.tag == "Player")
        {
            //if cieling active:
            if( cieling.activeSelf )
            {
                //set transparent:
                cieling.SetActive(false);
            }
            else //cieling not active
            {
                //set opaque:
                cieling.SetActive(true);
            }
        }
    }
}
