using UnityEngine;
using System.Collections;

public class ScoreWidget : MonoBehaviour {
	public GUIStyle scoreStyle, scoreLabelStyle;
	public float widgetWidth;
	public float widgetHeight;
	
	private UIManager ui;
	
	private int _amount;
	public int amount {
		get { return _amount; }
		set { _amount = value; }
	}
	
	void Start() {
		ui = transform.parent.GetComponent<UIManager>();	
	}
	
	void OnGUI() {
		float top = ui.life.widgetHeight + 10;
		
		GUI.Label(new Rect(Screen.width - widgetWidth - 10, top, widgetWidth, widgetHeight), _amount.ToString("000"), scoreStyle);
		GUI.Label(new Rect(Screen.width - widgetWidth, top + 3, 50, 40), "Score", scoreLabelStyle);
	}
}
