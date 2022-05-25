using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
	public float moveSpeed = PlayerManagerTmp.instance.GetPlayerSpeed();

	public Rigidbody2D rb;

	private Vector2 movement;

	private float damageTmp;
	private float damage;
	private bool dmg;

	public Animator animator;


	//Vars taken from LightBandit

	public float playerJumpForce = PlayerManagerTmp.instance.GetPlayerJump();
	private Sensor_Bandit m_groundSensor;
	private bool m_grounded = false;
		//private bool m_combatIdle = false;
		//private bool m_isDead = false;

	private bool isJumping = false;
	private BoxCollider2D playerCollider;
	private Vector2 ogColliderOffset;

	void Start()
	{
		damage = PlayerManagerTmp.instance.GetPlayerHealth();
		damageTmp = PlayerManagerTmp.instance.GetPlayerHealth();
		m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
		playerCollider = GetComponent<BoxCollider2D>();
		ogColliderOffset = playerCollider.offset;
	}
	// Update is called once per frame
	void Update()
	{
		print("is jumping = " + isJumping.ToString() + " and is grounded = " + m_grounded);



		//Check if character just landed on the ground
		if (!m_grounded && m_groundSensor.State())
		{
			isJumping = false;
			m_grounded = true;
			animator.SetBool("Grounded", m_grounded);
		}

		//Check if character just started falling
		if (m_grounded && !m_groundSensor.State())
		{
			m_grounded = false;
			animator.SetBool("Grounded", m_grounded);
		}

		movement.x = Input.GetAxisRaw("Horizontal");

		animator.SetFloat("X", movement.x);
		animator.SetFloat("Speed", movement.sqrMagnitude);

		/*
		//if player dead
		if (m_isDead)
		{
			m_isDead = false;
		}

		// -- Handle Animations --

		
		//Death
		// if player health below 0
		if (PlayerManagerTmp.instance.GetPlayerHealth() <= 0)
		{
			//if player not already dead
			if (!m_isDead)
			{
				//kill player
				animator.SetTrigger("Die");
				m_isDead = true;
			}
		}
		*/

		//Jump
		if (Input.GetKeyDown("space") && m_grounded)
		{
			animator.SetTrigger("Jump");
			m_grounded = false;
			animator.SetBool("Grounded", m_grounded);
			rb.velocity = new Vector2(rb.velocity.x, playerJumpForce);
			m_groundSensor.Disable(0.2f);

			isJumping = true;
		}

		damageTmp = damage;
		damage = PlayerManagerTmp.instance.GetPlayerHealth();
		if (damage - damageTmp != 0.0)
		{
			dmg = true;
			Debug.Log("DmgTriggerAnimation");
		}
		else dmg = false;
		animator.SetBool("Dmg", dmg);

		moveSpeed = PlayerManagerTmp.instance.GetPlayerSpeed();
		playerJumpForce = PlayerManagerTmp.instance.GetPlayerJump();
	}

	void FixedUpdate()
	{
		//move player based on moveSpeed
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		//if player not grounded + jumped
		if (!m_grounded && isJumping)
		{
			//set collider to higher
			playerCollider.offset = new Vector2(playerCollider.offset.x, 0.35f);
		}
		//player grounded
		else if (m_grounded)
		{
			isJumping = false;

			//rst collider offset
			playerCollider.offset = ogColliderOffset;

			
		}

		//if grounded but jumping still set so collider not reset
		if( m_grounded && isJumping)
        {
			//apply small pulse to get player unstuck
			rb.AddForce(Vector2.up * 500f, ForceMode2D.Impulse);
		}

		// Move
		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

	}
}
