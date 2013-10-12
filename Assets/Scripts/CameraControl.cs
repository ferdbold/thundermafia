﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public float polly = -10;

	void Update () {
		//transform.position = new Vector3(transform.parent.position.x * 0.5f, transform.parent.position.y * 0.5f, polly);
		Vector3 buffer = transform.position;
		buffer.x = transform.parent.position.x * 0.5f;
		buffer.y = transform.parent.position.y * 0.5f;
		transform.position = buffer;
	}
}
