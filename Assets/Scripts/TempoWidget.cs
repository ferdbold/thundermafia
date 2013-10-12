using UnityEngine;
using System.Collections;

public class TempoWidget : MonoBehaviour {
	public float widgetHeight;
	private float _progress;
	public float progress {
		get { return _progress; }
		set { _progress = value; }
	}
	
	public GUIStyle tempoStyle;
	
	void OnGUI() {
		Texture2D blanc = new Texture2D(1, 1);
		blanc.SetPixel(0, 0, Color.red);
		blanc.wrapMode = TextureWrapMode.Repeat;
		blanc.Apply();
		
		GUI.skin.box.normal.background = blanc;
		GUI.Box(new Rect(0, Screen.height - widgetHeight, Screen.width * progress, widgetHeight), GUIContent.none);
		Debug.Log(_progress);
	}
	
	void Update () {
		
	}
	
	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
