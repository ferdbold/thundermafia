﻿using UnityEngine;
using System.Collections;

public class RingSpawner : MonoBehaviour {
	
	public GameObject circle;
	private int z = 6;
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void nextStage()
	{
		Instantiate(circle, new Vector3(0, 0, this.z), circle.transform.rotation);
		z += 5;
	}
}
