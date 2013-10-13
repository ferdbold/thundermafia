using UnityEngine;
using System.Collections;

public class GoalWidget : MonoBehaviour {
	public int widgetHeight = 20;
	private Color colorUncleared;
	private Color colorCleared;
	public Texture2D test;
	
	private UIManager ui;
	private GameManager game;
	
	private float _amount;
	public float amount {
		get { return _amount; }
		set { _amount = value; }
	}
	
	void Start() {
		ui = transform.parent.gameObject.GetComponentInChildren<UIManager>();
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		colorUncleared = Color.yellow;
		colorCleared = Color.green;
	}
	
	void OnGUI() {
		Color activeColor;
		
		if (_amount < game.difficulty) {
			activeColor = colorUncleared;
			//Debug.Log("Uncleared");
		} else {
			activeColor = colorCleared;
			//Debug.Log("Cleared");
		}
		
		Texture2D goalTex = new Texture2D(1, 1);
		goalTex.SetPixel(0, 0, activeColor);
		goalTex.wrapMode = TextureWrapMode.Repeat;
		goalTex.Apply();
		
		GUI.skin.box.normal.background = goalTex;
		float trucY = Screen.height - ui.tempo.widgetHeight - widgetHeight - 2;
		
		GUI.Box(new Rect(0, trucY, Screen.width * _amount, widgetHeight), GUIContent.none);
	}
}
