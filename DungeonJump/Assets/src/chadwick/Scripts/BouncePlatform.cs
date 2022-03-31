using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField]
    public float bounceHeight = 20f;
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if collided with player
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceHeight, ForceMode2D.Impulse);
        }
    }
}
