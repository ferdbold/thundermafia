using UnityEngine;
using System.Collections;

public class HexBehaviour : MonoBehaviour {
	private float rotationFactor;
	
	void Start () {
		rotationFactor = Random.Range(-100, 100);
	}
	
	void Update () {
		transform.Rotate(new Vector3(0, rotationFactor * Time.deltaTime, 0));
	}
}
