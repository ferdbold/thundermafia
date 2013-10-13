using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{
	public float speed = 100;
	public float maxRotation = 90;
	public float distanceBeforeAttacking = 200;
	public GameObject bullet;
	public int frequencyOfAttacks = 50;
	private int it;
	public enum State{active,passive};
	public State state = State.active;
	
	// Use this for initialization
	void Start ()
	{
		it = frequencyOfAttacks;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.z == GameInfo.GetPlayerLocation ().z)
			state = State.active;
		else
		{
			state = State.passive;
			
			if(transform.position.z <= GameInfo.GetPlayerLocation ().z -100)
				Destroy (this.gameObject);
		}
		Move ();
	}
	
	/// <summary>
	/// Move this instance.
	/// </summary>
	private void Move ()
	{
		if (state == State.active) {
			Vector3 nextLocation = transform.position;		
			Vector3 desired = GameInfo.GetPlayerLocation () - transform.position;
			desired.z = 0;
			Vector3 the_return = Vector3.RotateTowards (transform.forward, desired, Mathf.Deg2Rad * maxRotation * Time.deltaTime, 1);
			transform.rotation = Quaternion.LookRotation (the_return);
		
			if (GameInfo.GetPlayerDistanceFromPoint (transform.position) > distanceBeforeAttacking) {
				transform.Translate (0, 0, speed);
			} else if (it >= frequencyOfAttacks) {
				it = 0;
				Attack ();
			}
			it++;
		}
	}
	
	/// <summary>
	/// Attack the player.
	/// </summary>
	private void Attack ()
	{
		GameObject test = (GameObject)GameObject.Instantiate (bullet, transform.position, transform.rotation);
		test.gameObject.tag = "EnemyProjectile";
		test.gameObject.transform.parent = this.transform;
	}
}
