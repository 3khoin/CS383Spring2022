using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : MonoBehaviour, Interactable
{
    public float incrAmt = 0.1f;

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
            collision.gameObject.GetComponent<MainPlayer>().moveSpeed += moveSpeed * incrAmt; //increases by incrAmt of og move speed
        }
    }

    public void PlayerPickup()
    {
        //make item dissapear:
        gameObject.SetActive(false);

    }
}
