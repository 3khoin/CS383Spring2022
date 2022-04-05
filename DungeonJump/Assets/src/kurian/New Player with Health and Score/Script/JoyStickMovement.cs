using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMovement : MonoBehaviour
{

	public CharacterController2D controller;

	public Joystick joystick;



	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{

		if (joystick.Horizontal >= .2f)
        {
			horizontalMove = runSpeed;
        }
		else if (joystick.Horizontal <= -.2f)
        {
			horizontalMove = -runSpeed;
        }
		else
        {
			horizontalMove = 0f;
        }
		float verticalMove = joystick.Vertical;


		//FOR JUMPING IN JOYSTICK
		if (verticalMove >= .5f)
		{
			jump = true;
		}

		//FOR MAKE THE PLAYER SITDOWN
		if (verticalMove <= -.5f)
		{
			crouch = true;
		}
		else
		{
			crouch = false;
		}

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}