using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFloor : MonoBehaviour
{
    public GameObject cieling;
    private bool cielingState; 

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
        if( collision.gameObject.tag == "Player") //player entered building bc triggered floor tile
        {
            cieling.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //player exited building bc left floor tiles
        {
            cieling.SetActive(true);
        }
    }
}
