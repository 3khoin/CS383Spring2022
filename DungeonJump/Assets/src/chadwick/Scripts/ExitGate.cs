using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGate : MonoBehaviour
{
    [SerializeField]
    public string levelName = "Overworld Spawn Area";
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
        // if collide with player:
        if( collision.gameObject.tag == "Player")
        {
            //change lvl to overworld:
            SceneManager.LoadScene(levelName);
        }
    }
}
