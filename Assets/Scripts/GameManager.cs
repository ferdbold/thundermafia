using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject ringPrefab;
	
	private Deplacement player;
	private UIManager ui;
	private GameManagerState _state;
	private int z = 0;
	private int _ringJump = 50;
	
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Deplacement>();
		ui = GameObject.Find("UIManager").GetComponent<UIManager>();
		
		SpawnRings();
		_state = new IdleGameManagerState(this);
	}
	
	// Update is called once per frame
	void Update () {
		_state.Update();
	}
	
	public void AnimateRingChange(float ratio) {
		player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(0, 0, _ringJump/16), ratio);
	}
	
	/// <summary>
	/// Spawns the rings.
	/// </summary>
	private void SpawnRings() {
		while (z < 10000) {
			Instantiate(ringPrefab, new Vector3(0, 0 , z), ringPrefab.transform.rotation);
			z += _ringJump;
		}
	}
	
	public void OnRingChange(float ratio) {
		_state.OnRingChange(ratio);
	}
	
	abstract private class GameManagerState {
		protected GameManager _manager;
		
		public GameManagerState(GameManager manager) {
			_manager = manager;	
		}
		
		virtual public void Update() {}
		virtual public void OnRingChange(float ratio) {}
	}
	
	private class IdleGameManagerState : GameManagerState {
		public IdleGameManagerState(GameManager manager) : base(manager) {
			
		}
		
		override public void OnRingChange(float ratio) {
			_manager._state = new RingChangeGameManagerState(_manager);	
		}
	}
	
	private class RingChangeGameManagerState : GameManagerState {
		public RingChangeGameManagerState(GameManager manager) : base(manager) {
				
		}
		
		override public void OnRingChange(float ratio) {
			_manager.player.transform.position = Vector3.Lerp(_manager.player.transform.position, _manager.player.transform.position + new Vector3(0, 0, _manager._ringJump/16), ratio);
		}
	}		
}
