using UnityEngine;
using System.Collections;

public class Deplacement : MonoBehaviour {
	// Vitesse du vaisseau
	public float decay = 0.99f;
<<<<<<< HEAD
	public float speed = 20;
	public float maxSpeed = 10;
	
	// Position max du vaisseau
	public float radiusArene = 5;
	public float playerPosVMin   = -10.0f;
	public float playerPosVMax   = 10.0f;
	public float playerPosHMin   = -10.0f;
	public float playerPosHMax   = 10.0f;
=======
	public float speed = 0.001f;
	public float maxSpeed = 10;
	
	// Position max du vaisseau
	public float radiusArene = 10;
>>>>>>> 4a3b710ba6e54a3930fcccb7daec53f226024ad5
	
	// Position de départ
	public float playerPosHStart = 0f;
	public float playerPosVStart = 0f;
	
	// Vecteur de vélocité
	public Vector3 dir = Vector3.zero;
	public Vector3 velocity;
	
	// Update is called once per frame
	void Update () {
		dir.x = Input.GetAxis("Horizontal");
		dir.y = Input.GetAxis("Vertical");
		dir = Vector3.ClampMagnitude(dir, 1);
		
		// Bordures de l'écran
		float deltaArene = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) - radiusArene;
		if (deltaArene > 0) {
			Vector3 repelForce = Vector3.Normalize(new Vector3(transform.position.x, transform.position.y, 0));
			
			dir -= repelForce * deltaArene;
			dir = Vector3.ClampMagnitude(dir, 1);
		}
		
<<<<<<< HEAD
		velocity.x = dir.x * speed * Time.deltaTime;
		velocity.y = dir.y * speed * Time.deltaTime;
=======
		velocity.x += dir.x * speed * Time.deltaTime;
		velocity.y += dir.y * speed * Time.deltaTime;
>>>>>>> 4a3b710ba6e54a3930fcccb7daec53f226024ad5
		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
		velocity *= decay;
		
		transform.Translate(velocity);
	}
	
	public void ResetPosition() {
		float z = transform.position.z;
		this.transform.position = new Vector3(playerPosHStart, playerPosVStart, z);
	}
}
