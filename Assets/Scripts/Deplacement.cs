using UnityEngine;
using System.Collections;

public class Deplacement : MonoBehaviour {
	
	// Vitesse de déplacement
	public float playerSpeedV    = 10.0f;
	public float playerSpeedH    = 10.0f;
	
	// Position max du vaisseau
	public float playerPosVMin   = -10.0f;
	public float playerPosVMax   = 10.0f;
	public float playerPosHMin   = -10.0f;
	public float playerPosHMax   = 10.0f;
	
	// Position de départ
	public float playerPosHStart = 0f;
	public float playerPosVStart = -4.5f;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		float transH = 0;
		float transV = 0;
		Vector3 dir = Vector3.zero;
		
		// Inertie du vaisseau si aucune touche n'est pressée
		if (Input.anyKey == false){
			dir.x = Input.acceleration.x;
			dir.y = Input.acceleration.y;
			transH = dir.x * (playerSpeedH + 10.0f) * Time.deltaTime;
			transV = dir.y * (playerSpeedV + 10.0f) * Time.deltaTime;
		}
		
		else{
		// Déplacement du vaisseau
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Z)){
			transV = playerSpeedV * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.Q)){
			transH = -playerSpeedH * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)){
			transH = playerSpeedH * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)){
			transV = -playerSpeedV * Time.deltaTime;
		}
		}
		
		transform.Translate(transH, transV, 0);
		
		// Initialisation de z
		float z = transform.position.z;
		
		// Vérifier que le vaisseau ne sort pas de l'écran
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, playerPosHMin, playerPosHMax),
	                                     Mathf.Clamp(transform.position.y, playerPosVMin, playerPosVMax),
										 z);
		
		/*if (positionH < playerPosVMin){
			transform.Translate(new Vector3(0,1,0));				
		}*/
		
	}
	
	public void ResetPosition() {
		float z = transform.position.z;
		this.transform.position = new Vector3(playerPosHStart, playerPosVStart, z);
	}
}
