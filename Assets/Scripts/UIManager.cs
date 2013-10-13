
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	private TempoWidget _tempoWidget;
	public TempoWidget tempo {
		get { return _tempoWidget; }
	}
	
	private LifeWidget _lifeWidget;
	public LifeWidget life {
		get { return _lifeWidget; }
	}
	
	private GoalWidget _goalWidget;
	public GoalWidget goal {
		get { return _goalWidget; }
	}
	
	void Awake () {
		_tempoWidget = transform.GetComponentInChildren<TempoWidget>();
		_lifeWidget = transform.GetComponentInChildren<LifeWidget>();
		_goalWidget = transform.GetComponentInChildren<GoalWidget>();
	}
}
