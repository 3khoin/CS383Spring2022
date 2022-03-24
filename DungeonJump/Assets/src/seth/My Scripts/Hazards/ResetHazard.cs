using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHazard : Hazard
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            print("Scene should be reset");

            //reset scene:
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
