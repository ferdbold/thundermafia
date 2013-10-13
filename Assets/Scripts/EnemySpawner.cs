using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	private int actualStage = -1;
	private bool stageStarted = false;
	private int zMultiplicator = 50;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (stageStarted) {
		//	stageStarted = false;
			
			//if(actualStage!=GameManager.GetActualStage())
			//{
			Vector3 spawningPoint = new Vector3(Random.Range (-50f,50f),Random.Range (-50f,50f),zMultiplicator*(actualStage+1));
		GameObject test = (GameObject)GameObject.Instantiate (enemy, spawningPoint, transform.rotation);
		test.gameObject.tag="Enemy";
		test.gameObject.transform.parent = this.transform;	
		//spawningPoint.z=zMultiplicator*(actualStage+1);
			//}
	//	}
	}
}
