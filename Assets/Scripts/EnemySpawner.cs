﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public static int actualStage = 0;
	public static bool canSpawnEnemy = true;
	private static int zMultiplicator = 50;
	private static int enemiesToSpawn=0;
	private bool firstLvlEnemiesSpawned=false;
	private float rnd;
	private int enemyFireRate;
	private int nbrOfEnemiesSpawned;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(actualStage==0 && !firstLvlEnemiesSpawned)
		{
			System.Random rand = new System.Random();
			enemiesToSpawn=1;
			
			for(int i=0; i<actualStage+1; i++)
			{
				Vector3 randomSpawningPoint = Random.insideUnitCircle*GameManager.arenaRadius;
				Quaternion randomRotation = Random.rotation;
				randomRotation.y=0;
				randomRotation.z=0;
				randomRotation.w=0;
				randomSpawningPoint.z=(actualStage)*zMultiplicator;
				GameObject spawnedEnemy = (GameObject)GameObject.Instantiate (enemy, randomSpawningPoint, randomRotation);
				spawnedEnemy.transform.Rotate (0f,90f,90f);
				spawnedEnemy.gameObject.tag = "Enemy";
				spawnedEnemy.gameObject.transform.parent = this.transform;
				enemiesToSpawn--;
			}
			
			firstLvlEnemiesSpawned=true;
		}
		
		if (canSpawnEnemy || enemiesToSpawn>0) {
			if(enemiesToSpawn==0)
			{
				rnd = 100*actualStage;
				int nbrOfEnemies = Random.Range(0,(int)((int)(rnd/70f)));
				rnd-=nbrOfEnemies;
				enemiesToSpawn = 1+nbrOfEnemies;
				nbrOfEnemiesSpawned=enemiesToSpawn;
				
				enemyFireRate = Random.Range(0, (int)(actualStage*(rnd/10)));
				rnd-=enemyFireRate;
			}
			
			canSpawnEnemy = false;
			System.Random rand = new System.Random();
			
			for(int i=0; i<enemiesToSpawn; i++)
			{
				Vector3 randomSpawningPoint = Random.insideUnitCircle*GameManager.arenaRadius;
				Quaternion randomRotation = Random.rotation;
				randomRotation.y=0;
				randomRotation.z=0;
				randomRotation.w=0;
				randomSpawningPoint.z=(actualStage+1)*zMultiplicator;
				GameObject spawnedEnemy = (GameObject)GameObject.Instantiate (enemy, randomSpawningPoint, randomRotation);
				//spawnedEnemy.transform.Rotate (0f,90f,90f);
				spawnedEnemy.gameObject.tag = "Enemy";
				spawnedEnemy.gameObject.transform.parent = this.transform;
				
				EnemyIA enemyIA = spawnedEnemy.GetComponent<EnemyIA>();
					enemyIA.frequencyOfAttacks=enemyFireRate;
				enemyIA.goal = 1f/(float)nbrOfEnemiesSpawned;
			}
			enemiesToSpawn=0;
		}
	}
}
