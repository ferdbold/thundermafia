using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public float followFactor = 0.5f;
	
	void Update () {
		Vector3 buffer = transform.position;
		buffer.x = transform.parent.position.x * followFactor;
		buffer.y = transform.parent.position.y * followFactor;
		transform.position = buffer;
	}
}
