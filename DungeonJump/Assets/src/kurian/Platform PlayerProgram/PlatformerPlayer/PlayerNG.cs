using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNG : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirectioin;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirectioin = new Vector2(moveX, moveY).normalized; 
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirectioin.x * moveSpeed, moveDirectioin.y * moveSpeed);
    }
}
