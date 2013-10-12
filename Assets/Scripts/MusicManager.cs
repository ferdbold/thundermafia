using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip mainMusic;
	public AudioClip introBossMusic;
	public AudioClip bossMusic;
	
	private GameManager game;
	private UIManager ui;
	private MusicManagerState _state;
	
	private float _timeSinceLastMusicTick;
	private float _animStartPercentage = 0.8F;
	
	private float _bpm;
	public float bpm {
		get { return _bpm; }
		set { _bpm = value; }
	}
	
	void Start() {
		_state = new NormalMusicState(this);
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		ui = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	void Update () {
		_state.Update();
	}
	
	abstract private class MusicManagerState {
		protected MusicManager _manager;
		
		public MusicManagerState(MusicManager manager) {
			_manager = manager;
		}
		
		virtual public void Update() {
			// Synchronisation avec musique
			float nextTick = 240 / _manager.bpm;
			float lengthAnimation = nextTick * (1 - _manager._animStartPercentage);
			float minThreshold = nextTick * _manager._animStartPercentage;
			float deltaAnimation = Mathf.Min(_manager._timeSinceLastMusicTick - minThreshold, lengthAnimation);
			float progressRatio = _manager._timeSinceLastMusicTick / nextTick;
			float animRatio = deltaAnimation / lengthAnimation;
			
			_manager._timeSinceLastMusicTick += Time.deltaTime;
			_manager.ui.tempo.progress = progressRatio;
			
			// Transition des anneaux à chaque mesure
			if (_manager._timeSinceLastMusicTick >= minThreshold) {
				_manager.game.OnRingChange(animRatio);
				
				if (_manager._timeSinceLastMusicTick >= nextTick) {
					_manager._timeSinceLastMusicTick = 0;	
				}
			}	
		}
	}
	
	private class NormalMusicState : MusicManagerState {
		public NormalMusicState(MusicManager manager) : base(manager) {
			_manager.audio.clip = _manager.mainMusic;
			_manager.audio.Play();
			_manager.bpm = 87.5f;
		}	
		
		override public void Update() {
			base.Update();
			if (Input.GetKey(KeyCode.Return)) {
				_manager._state = new IntroBossMusicManagerState(_manager);
			}
		}
	}
	
	private class IntroBossMusicManagerState : MusicManagerState {
		public IntroBossMusicManagerState(MusicManager manager) : base(manager) {
			_manager.audio.clip = _manager.introBossMusic;
			_manager.audio.Play();
			_manager.bpm = 0;
		}
		
		override public void Update() {
			if (!_manager.audio.isPlaying) {
				_manager._state = new BossMusicManagerState(_manager);	
			}
		}
	}
	
	private class BossMusicManagerState : MusicManagerState {
		public BossMusicManagerState(MusicManager manager) : base(manager) {
			_manager.audio.clip = _manager.bossMusic;
			_manager.audio.Play();
			_manager.bpm = 290;
		}
		
		override public void Update() {
			base.Update();
			if (Input.GetKey(KeyCode.Return)) {
				_manager._state = new NormalMusicState(_manager);	
			}
		}
	}
}
