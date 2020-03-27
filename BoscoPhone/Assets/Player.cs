using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		/*If player gets hit by enemy boss every so ofter
			Maybe would Should have it as the Enemy hits the player
			if the player doesn't acheive the entire swipe?*/
		if (Input.GetKeyDown(KeyCode.Space)) //This is meant for jumping,Change for our game.
		{
			TakeDamage(20);
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
