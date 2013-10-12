﻿using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{
	public float speed = 100;
	public float maxRotation=90;
	public float distanceBeforeAttacking = 200;
	public GameObject bullet;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}
	
	/// <summary>
	/// Move this instance.
	/// </summary>
	private void Move ()
	{
		Vector3 nextLocation = transform.position;		
		Vector3 desired = GameInfo.GetPlayerLocation () - transform.position;
		desired.z=0;
		Vector3 the_return = Vector3.RotateTowards (transform.forward, desired, Mathf.Deg2Rad * maxRotation * Time.deltaTime, 1);
		transform.rotation = Quaternion.LookRotation (the_return);
		
		if (GameInfo.GetPlayerDistanceFromPoint (transform.position) > distanceBeforeAttacking) {
			transform.Translate (0, 0, speed);
		}
		else
			Attack();
	}
	
	/// <summary>
	/// Attack the player.
	/// </summary>
	private void Attack()
	{
		GameObject test = (GameObject)GameObject.Instantiate (bullet);
		test.transform.position = transform.position;
		test.gameObject.tag="EnemyProjectile";
		test.gameObject.transform.parent = this.transform;
	}
}