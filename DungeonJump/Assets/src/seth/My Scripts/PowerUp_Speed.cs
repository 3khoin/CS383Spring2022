using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : MonoBehaviour, Interactable
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
        //if collided w/ player:
        if (collision.gameObject.tag == "Player")
        {
            //have player pickup:
            PlayerPickup();

            //increase player's speed:
            float moveSpeed = collision.gameObject.GetComponent<MainPlayer>().moveSpeed;
            collision.gameObject.GetComponent<MainPlayer>().moveSpeed += moveSpeed / 10; //increases by a tenth of og move speed
        }
    }

    public void PlayerPickup()
    {
        //make item dissapear:
        gameObject.SetActive(false);

    }
}
