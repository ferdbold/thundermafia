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
	private EnemyIAState _state;
	public float goal;
	
	// Use this for initialization
	void Start ()
	{
		it = frequencyOfAttacks;
		_state = new EnemyPassiveState (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_state.Update ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "PlayerProjectile") {
			Projectile projectile = other.GetComponent<Projectile> ();
			GameManager gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			gm.AddToGoal (goal);
			Destroy (transform);
		}
	}
	
	/// <summary>
	/// Classe de base pour les états des ennemis
	/// </summary>
	abstract private class EnemyIAState
	{
		protected EnemyIA _ia;
		
		public EnemyIAState (EnemyIA ia)
		{
			_ia = ia;
		}
		
		virtual public void Update ()
		{
		}
		
		virtual public void Move ()
		{
		}
	}
	
	/// <summary>
	/// État passif (n'attaque pas le joueur)
	/// </summary>
	private class EnemyPassiveState:EnemyIAState
	{
		public EnemyPassiveState (EnemyIA ia):base(ia)
		{
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		override public void Update ()
		{
			base.Update ();
			Vector3 playerZ = GameInfo.GetPlayerLocation ();
			playerZ.x = 0;
			playerZ.y = 0;
			Vector3 enemyZ = _ia.transform.position;
			enemyZ.x = 0;
			enemyZ.y = 0;
			
			if (_ia.transform.position.z <= GameInfo.GetPlayerLocation ().z - 10)
				Destroy (_ia.gameObject);
			
			if (Vector3.Distance (playerZ, enemyZ) <= 3f)
				_ia._state = new EnemyActiveState (_ia);
			
			Move ();
		}
		
		/// <summary>
		/// Move this instance.
		/// </summary>
		override public void Move ()
		{
			// WANDERING
		}
	}
	
	/// <summary>
	/// État actif (attaque le joueur)
	/// </summary>
	private class EnemyActiveState:EnemyIAState
	{
		public EnemyActiveState (EnemyIA ia):base(ia)
		{
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		override public void Update ()
		{
			base.Update ();
			Vector3 playerZ = GameInfo.GetPlayerLocation ();
			playerZ.x = 0;
			playerZ.y = 0;
			Vector3 enemyZ = _ia.transform.position;
			enemyZ.x = 0;
			enemyZ.y = 0;
			
			if (_ia.transform.position.z <= GameInfo.GetPlayerLocation ().z - 10 && !GameManager.bossArea)
				Destroy (_ia.gameObject);
			
			if (Vector3.Distance (playerZ, enemyZ) > 3f && !GameManager.bossArea)
				_ia._state = new EnemyPassiveState (_ia);

			Move ();
		}
		
		/// <summary>
		/// Move enemy.
		/// </summary>
		override public void Move ()
		{
			Vector3 nextLocation = _ia.transform.position;		
			Vector3 desired = GameInfo.GetPlayerLocation () - _ia.transform.position;
			
			if (!GameManager.bossArea)
				desired.z = 0;
			Vector3 the_return = Vector3.RotateTowards (_ia.transform.forward, desired, Mathf.Deg2Rad * _ia.maxRotation * Time.deltaTime, 1);
			if (!GameManager.bossArea)
				the_return.z = 0;
			_ia.transform.rotation = Quaternion.LookRotation (the_return);
		
			if (GameInfo.GetPlayerDistanceFromPoint (_ia.transform.position) > _ia.distanceBeforeAttacking) {
				float move = _ia.speed;
				if (GameInfo.GetPlayerDistanceFromPoint (_ia.transform.position) < _ia.speed)
					move = GameInfo.GetPlayerDistanceFromPoint (_ia.transform.position);
				_ia.transform.Translate (0, 0, move);
			} else if (_ia.it >= _ia.frequencyOfAttacks) {
				_ia.it = 0;
				Attack ();
			}
			_ia.it++;
		}
		
		/// <summary>
		/// Attack player.
		/// </summary>
		private void Attack ()
		{
			GameObject test = (GameObject)GameObject.Instantiate (_ia.bullet, _ia.transform.position, _ia.transform.rotation);
			test.gameObject.tag = "EnemyProjectile";
			test.gameObject.transform.parent = _ia.transform;
		}
	}
}
