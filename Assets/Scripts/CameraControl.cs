using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	void Update () {
		Vector3 buffer = transform.position;
		buffer.x = transform.parent.position.x * 0.5f;
		buffer.y = transform.parent.position.y * 0.5f;
		transform.position = buffer;
	}
}
