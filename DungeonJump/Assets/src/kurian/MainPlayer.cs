using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;

	private Vector2 movement;

	private float damageTmp;
	
	private float damage;

	private bool dmg;

	public Animator animator;
    private bool m_isDead;

    void Start()
	{
	    damage = PlayerManagerTmp.instance.GetPlayerHealth();
	    damageTmp = PlayerManagerTmp.instance.GetPlayerHealth();
	
	}
	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("X", movement.x);
		animator.SetFloat("Y", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

		/*
		//if player dead
		if (m_isDead)
		{
			m_isDead = false;
		}

		//Death
		// if player health below 0
		if (PlayerManagerTmp.instance.GetPlayerHealth() <= 0)
		{
			//if player not already dead
			if (!m_isDead)
			{
				print("player should die");

				//kill player
				animator.SetTrigger("Die");
				m_isDead = true;
			}
		}
		*/

		damageTmp = damage;
		damage = PlayerManagerTmp.instance.GetPlayerHealth();
		if (damage - damageTmp != 0.0)
		{
			dmg = true;
			Debug.Log("DmgTriggerAnimation");
		}
		else dmg = false;
		animator.SetBool("Dmg", dmg);
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
	
}
