using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float speed = 10;
	public float live = 1000;
	public int damage = 0;
	
	// Use this for initialization
	void Start ()
	{
		transform.rotation = transform.parent.rotation;
		Destroy (this.gameObject, live);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, 0, speed);
	}
}
