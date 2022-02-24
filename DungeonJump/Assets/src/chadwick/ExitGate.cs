using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitGate : MonoBehaviour
{
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
        //check collision with player
        if( collision.gameObject.tag == "Player")
        {
            //change level to the overworld level
            SceneManager.LoadScene( 0 );
        }
    }

}
