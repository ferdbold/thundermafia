using UnityEngine;
using System.Collections;

public class ShootingPlayer : MonoBehaviour {
	
	public GameObject bullet;
	public float fireRate = 0.1f;
	private float nextBullet = 0.0f;	
	private Vector3 mousePos;
	private float posX;
	public float maxRotation = 360;
	//private float posY;

	// Use this for initialization
	void Start () {

	}
	
	// Le vaisseau tire tant que le joueur appuie sur le bouton gauche de la souris
	void Update () {
		
		/*
		mousePos = Input.mousePosition;
    	mousePos.z = -10.0f; //The distance between the camera and object
    	objectPos = Camera.main.WorldToScreenPoint(player.position);	
    	mousePos.x = mousePos.x - objectPos.x;
    	mousePos.y = mousePos.y - objectPos.y;
		angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;    		
		transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
		*/
		/*
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			
			posX = hit.transform.position.x;
			
			posY = hit.transform.position.y;
			
			//Vector3 target = new Vector3(posX, posY, transform.position.z);
			
			//transform.LookAt(target);
			
		 */
			
		mousePos = Input.mousePosition;
		
		Vector3 the_return = Vector3.RotateTowards (transform.forward, mousePos, Mathf.Deg2Rad * maxRotation * Time.deltaTime, 1);
		
		transform.rotation = Quaternion.LookRotation (the_return);
		
		//transform.rotation.LookRotation(Quaternion.Euler(mousePos));
		
		
		if (Input.GetButton("Fire1") && Time.time > nextBullet){
				
				//transform.rotation = Quaternion.Euler(90, 0, 0);	
				nextBullet = Time.time + fireRate;
				GameObject tire = (GameObject)GameObject.Instantiate (bullet, transform.position, transform.rotation);
				tire.gameObject.tag="PlayerProjectile";
			}
			
			
		}

		
}
