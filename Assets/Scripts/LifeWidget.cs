using UnityEngine;
using System.Collections;

public class LifeWidget : MonoBehaviour {
	public float widgetHeight = 100;
	
	private float _amount;
	public float amount {
		set { _amount = value; }
	}
	
	void OnGUI() {
		Texture2D lifeTex = new Texture2D(1, 1);
		lifeTex.SetPixel(0, 0, Color.green);
		lifeTex.wrapMode = TextureWrapMode.Repeat;
		lifeTex.Apply();
		
		GUI.skin.box.normal.background = lifeTex;
		GUI.Box(new Rect(0, 0, Screen.width * _amount / 100, widgetHeight), GUIContent.none);
	}
}
