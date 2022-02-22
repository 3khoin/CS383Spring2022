using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Color highlightColor;

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
        //if collided w/ player:
        if (collision.gameObject.tag == "Player")
        {
            //have player pickup:
            PlayerPickup();
        }
    }

    private void PlayerPickup()
    {
        //make item dissapear:
        gameObject.SetActive(false);

        //Add to LevelManager currItems
    }
}
