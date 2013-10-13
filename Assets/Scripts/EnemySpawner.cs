using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	private int actualStage = 0;
	public static bool canSpawnEnemy = false;
	private int zMultiplicator = 50;
	private int enemiesToSpawn=0;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canSpawnEnemy || enemiesToSpawn>0) {
			actualStage++;
			if(canSpawnEnemy)
				enemiesToSpawn=actualStage;
			canSpawnEnemy = false;
			System.Random rand = new System.Random();
			
			if(enemiesToSpawn>0)
			{
				Vector3 spawningPoint = new Vector3 ((float)rand.Next (-10,10), (float)rand.Next (-10,10), GameInfo.GetPlayerLocation ().z+50);
				GameObject test = (GameObject)GameObject.Instantiate (enemy, spawningPoint, transform.rotation);
				test.gameObject.tag = "Enemy";
				test.gameObject.transform.parent = this.transform;
				enemiesToSpawn--;
			}
		}
	}
}
