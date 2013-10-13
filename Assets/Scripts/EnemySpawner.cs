using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	private int actualStage = 0;
	public static bool canSpawnEnemy = false;
	private int zMultiplicator = 50;
	private int enemiesToSpawn=0;
	public float radius=10;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canSpawnEnemy || enemiesToSpawn>0) {
			if(canSpawnEnemy)
				actualStage++;
			canSpawnEnemy = false;
			System.Random rand = new System.Random();
			
			for(int i=0; i<actualStage+1; i++)
			{
				Vector3 randomSpawningPoint = Random.insideUnitCircle*radius;
				Quaternion randomRotation = Random.rotation;
				randomRotation.y=0;
				randomRotation.z=0;
				randomRotation.w=0;
				randomSpawningPoint.z=GameInfo.GetPlayerLocation().z+radius;
				GameObject spawnedEnemy = (GameObject)GameObject.Instantiate (enemy, randomSpawningPoint, randomRotation);
				spawnedEnemy.transform.Rotate (0f,90f,90f);
				spawnedEnemy.gameObject.tag = "Enemy";
				spawnedEnemy.gameObject.transform.parent = this.transform;
				enemiesToSpawn--;
			}
		}
	}
}
