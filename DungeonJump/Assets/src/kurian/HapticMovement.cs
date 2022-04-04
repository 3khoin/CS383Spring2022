using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HapticMovement : MonoBehaviour
{
	public Text gyro;
	public CharacterController2D controller;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	// Use this for initialization
	void Start()
	{
		
	}
	// Update is called once per frame
	void Update() 
	{ 
	

		if (Input.acceleration.x >= 0.3f)
		{
			//gyro.text = Input.acceleration.x.ToString();
			horizontalMove = runSpeed;
		}
		else if (Input.acceleration.x <= -0.3f)
		{
			//gyro.text = Input.acceleration.x.ToString();
			horizontalMove = -runSpeed;
		}
		else
		{
			horizontalMove = 0f;
		}

		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	
}