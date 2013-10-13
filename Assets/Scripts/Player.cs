using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float life = 100;
	
	public UIManager ui;
	
	void Start() {
		ui = GameObject.Find("UIManager").GetComponent<UIManager>();
		life = 100;
		UpdateLife();
	}
	
	void Update() {
		if (Input.GetKeyUp(KeyCode.Space)) {
			TakeDamage(5);	
		}
	}
	
	public void TakeDamage(int amount) {
		life -= amount;
		if (life <= 0) {
			Die();
		}
		
		UpdateLife();
	}
	
	public void Die() {
		Debug.Log("You're dead bro!");	
	}
	
	private void UpdateLife() {
		Debug.Log("UpdateLife: " + life);
		ui.life.amount = life;
	}
}
