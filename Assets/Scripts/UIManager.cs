
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	private TempoWidget _tempoWidget;
	public TempoWidget tempo {
		get { return _tempoWidget; }
	}
	
	void Start () {
		_tempoWidget = transform.GetComponentInChildren<TempoWidget>();
	}
}
