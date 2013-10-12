using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	private TempoWidget _tempoWidget;
	
	void Start () {
		_tempoWidget = transform.GetComponentInChildren<TempoWidget>();
	}
		
	TempoWidget tempo {
		get { return _tempoWidget; }
	}
}
