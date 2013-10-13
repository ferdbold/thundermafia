using UnityEngine;
using System.Collections;

public class RingBehaviour : MonoBehaviour {
	private float _rotationFactor;
	
	
	// Use this for initialization
	void Start () {
		_rotationFactor = Random.Range(-25, 25);
		transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, _rotationFactor * Time.deltaTime, 0));
	}
}
