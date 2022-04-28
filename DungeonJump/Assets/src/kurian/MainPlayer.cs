using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;

	private Vector2 movement;

	public Animator animator;

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("X", movement.x);
		animator.SetFloat("Y", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
