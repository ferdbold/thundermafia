using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{
	public float speed = 10;
	public float distanceBeforeAttacking = 200;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}
	
	private void Move ()
	{
		Vector3 nextLocation = transform.position;
		Vector3 test = GameInfo.GetPlayerLocation ();
		float test2 = GameInfo.GetPlayerDistanceFromPoint (transform.position);
		
		if (GameInfo.GetPlayerDistanceFromPoint (transform.position) > distanceBeforeAttacking) {
			nextLocation = Vector3.MoveTowards (transform.position, GameInfo.GetPlayerLocation (), -speed);
			Vector3 move = transform.position - nextLocation;
			move.y = 0;
			transform.Translate (move);
		}
	}
	
	private void Attack()
	{
	}
}
