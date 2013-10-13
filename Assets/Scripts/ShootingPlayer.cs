using UnityEngine;
using System.Collections;

public class ShootingPlayer : MonoBehaviour {
	
	public GameObject bullet;
	public float fireRate = 0.1f;
	private float nextBullet = 0.0f;	
	private Vector3 mousePos;
	private float posX;
	public float rotationMax = 360.0f;
<<<<<<< HEAD
	public AudioClip laser;
	

	// Use this for initialization
	void Start () {
		
	}
=======
	private Transform sprite;
	private Vector3 bufferTargetPos = new Vector3(0, 0, 0);

>>>>>>> 241552f82d827a849041bf73488683f32e55ec4e
	
	void Start() {
		sprite = transform.GetChild(0);
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos = Input.mousePosition;
		Vector3 targetPos = mousePos - objectPos;
		if (targetPos.x < 0) {
			sprite.Rotate(0, 0, 180);
			Vector2 texScale = sprite.gameObject.renderer.material.mainTextureScale;
			texScale.x *= -1;
			sprite.gameObject.renderer.material.mainTextureScale = texScale;
		}
	}

	// Le vaisseau tire tant que le joueur appuie sur le bouton gauche de la souris
	void Update () {
		
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos = Input.mousePosition;
		Vector3 targetPos = mousePos - objectPos;
		targetPos.z = transform.parent.position.z;
		if (bufferTargetPos.x * targetPos.x < 0 && targetPos.x != 0) {
			sprite.Rotate(0, 0, 180);
			Vector2 texScale = sprite.gameObject.renderer.material.mainTextureScale;
			texScale.x *= -1;
			sprite.gameObject.renderer.material.mainTextureScale = texScale;
		}
		bufferTargetPos = targetPos;
		
<<<<<<< HEAD
		Vector3 the_return = Vector3.RotateTowards (transform.forward, mousePos - objectPos, Mathf.Deg2Rad * rotationMax * Time.deltaTime, 1);
		
		transform.rotation = Quaternion.LookRotation (the_return);
		
		//transform.rotation.LookRotation(Quaternion.Euler(mousePos));
		
		
=======
		Debug.Log(targetPos);
		
		transform.LookAt(targetPos);

>>>>>>> 241552f82d827a849041bf73488683f32e55ec4e
		if (Input.GetButton("Fire1") && Time.time > nextBullet){
				
				audio.PlayOneShot(laser);
				//transform.rotation = Quaternion.Euler(90, 0, 0);	
				nextBullet = Time.time + fireRate;
				GameObject tire = (GameObject)GameObject.Instantiate (bullet, transform.position + transform.forward * 0.5f, transform.rotation);
				tire.gameObject.tag="PlayerProjectile";
			}
		}
}
