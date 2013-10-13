using UnityEngine;
using System.Collections;

public class TempoWidget : MonoBehaviour {
	public float widgetHeight;
	
	private float _progress;
	public float progress {
		set { _progress = value; }
	}
	
	public GUIStyle tempoStyle;
	
	void OnGUI() {
		Texture2D blanc = new Texture2D(1, 1);
		blanc.SetPixel(0, 0, Color.white);
		blanc.wrapMode = TextureWrapMode.Repeat;
		blanc.Apply();
		
		GUI.skin.box.normal.background = blanc;
		GUI.Box(new Rect(0, Screen.height - widgetHeight, Screen.width * _progress, widgetHeight), GUIContent.none);
	}
	
	void Update () {
		
	}
}
