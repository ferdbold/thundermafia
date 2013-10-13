using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float life = 100;
	public float lifeRegen = 0.05f;
	
	private float maxLife = 100;
	
	public UIManager ui;
	public GameManager game;
	
	void Start() {
		ui = GameObject.Find("UIManager").GetComponent<UIManager>();
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		life = 100;
		UpdateLife();
	}
	
	void Update() {
		if (Input.GetKeyUp(KeyCode.Space)) {
			TakeDamage(5);	
		} else if (Input.GetKeyUp(KeyCode.V)) {
			game.goal += 0.1f;
		}
		
		RegenLife();
	}
	
	public void TakeDamage(int amount) {
		life -= amount;
		if (life <= 0) {
			Die();
		}
		
		UpdateLife();
	}
	
	public void RegenLife() {
		life += lifeRegen;
		life = Mathf.Min(life, maxLife);
		
		UpdateLife();
	}
	
	public void Die() {
		Debug.Log("You're dead bro!");	
	}
	
	private void UpdateLife() {
		ui.life.amount = life;
	}
}
