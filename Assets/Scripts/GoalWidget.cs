using UnityEngine;
using System.Collections;

public class GoalWidget : MonoBehaviour {
	public int widgetHeight = 20;
	
	private float _amount;
	private UIManager ui;
	
	public float amount {
		get { return _amount; }
		set { _amount = value; }
	}
	
	void Start() {
		ui = transform.parent.gameObject.GetComponentInChildren<UIManager>();
	}
	
	void OnGUI() {
		Texture2D goalTex = new Texture2D(1, 1);
		goalTex.SetPixel(0, 0, Color.blue);
		goalTex.wrapMode = TextureWrapMode.Repeat;
		goalTex.Apply();
		
		GUI.skin.box.normal.background = goalTex;
		float trucY = Screen.height - ui.tempo.widgetHeight - widgetHeight - 2;
		
		GUI.Box(new Rect(0, trucY, Screen.width * _amount, widgetHeight), GUIContent.none);
	}
}
