using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexManager : MonoBehaviour {
	public List<GameObject> hexPrefabs;
	public float hexMaxVisionRange;
	public float hexMinVisionRange;
	public float step, stepVariation;
	public float variationXY;
	
	private GameObject player;
	private float _lastAddedZ = 0;
	
	void Start () {
		player = GameObject.Find("Player");
	}
	
	void Update () {
		// Ajouter des hex dans le background
		if (_lastAddedZ < player.transform.position.z + hexMaxVisionRange) {
			SpawnHex();	
		}
		
		// Retirer les hex derrière le joueur
		for(int i=0; i<transform.childCount; i++) {
			Transform hexLayer = transform.GetChild(i);
			if (hexLayer.position.z < player.transform.position.z + hexMinVisionRange) {
				DeleteHexLayer(hexLayer);	
			}
		}
	}
	
	private void SpawnHex() {
		_lastAddedZ += Random.Range(step-stepVariation, step+stepVariation);
		float spawnX = Random.Range(-variationXY, variationXY);
		float spawnY = Random.Range(-variationXY, variationXY);
		int layerIndex = Random.Range(0, hexPrefabs.Count);
		
		GameObject newHexLayer = GameObject.Instantiate(hexPrefabs[layerIndex], new Vector3(spawnX, spawnY, _lastAddedZ), hexPrefabs[layerIndex].transform.rotation) as GameObject;
		newHexLayer.name = "Hex at Z=" + _lastAddedZ.ToString();
		newHexLayer.transform.parent = transform;
	}
	
	private void DeleteHexLayer(Transform hexLayer) {
		GameObject.Destroy(hexLayer.gameObject);
	}
}
