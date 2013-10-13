using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject ringPrefab;
	public float difficulty = 0.6f;
	public float goal = 0;
	public int damagePerFailure = 25;
	public int score = 0;
	
	private Deplacement playerController;
	private Player playerLogic;
	private UIManager ui;
	private GameManagerState _state;
	private int z = 0;
	public int _ringJump = 50;
	
	void Start () {
		GameObject playerObj = GameObject.Find("Player");
		playerController = playerObj.GetComponent<Deplacement>();
		playerLogic = playerObj.GetComponent<Player>();
		ui = GameObject.Find("UIManager").GetComponent<UIManager>();
		
		SpawnRings();
		_state = new IdleGameManagerState(this);
	}
	
	void Update () {
		_state.Update();
	}
	
	public void AnimateRingChange(float ratio) {
		playerController.transform.position = Vector3.Lerp(playerController.transform.position, playerController.transform.position + new Vector3(0, 0, _ringJump/16), ratio);
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
	
	public void AddToGoal(float amount) {
		goal += amount;
		ui.goal.amount = goal;
	}
	
	public void SetGoal(float amount) {
		goal = amount;
		ui.goal.amount = goal;
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
		private Vector3 origPosition;
		
		public RingChangeGameManagerState(GameManager manager) : base(manager) {
			origPosition = _manager.playerController.transform.position;
		}
		
		override public void OnRingChange(float ratio) {
			_manager.playerController.transform.position = Vector3.Lerp(origPosition, origPosition + new Vector3(0, 0, _manager._ringJump), ratio);
			
			if (ratio >= 1) {
				CheckForSuccess();
				EnemySpawner.canSpawnEnemy=true; // Dit au EnemySpawner qu'il peut créer de nouveaux ennemis
				LevelUp();
				_manager._state = new IdleGameManagerState(_manager);
			}
		}
		
		private void CheckForSuccess() {
			if (_manager.goal < _manager.difficulty) {
				_manager.playerLogic.TakeDamage(_manager.damagePerFailure);	
			}
		}
		
		private void LevelUp() {
			_manager.SetGoal(0);
			_manager.score++;
			//_manager.ui.score.amount = _manager.score;
		}
	}
}
