using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip mainMusic;
	public AudioClip introBossMusic;
	public AudioClip bossMusic;
	
	private MusicManagerState _state;
	private bool _transitioning;
	
	void Start() {
		_state = new NormalMusicState(this);	
	}
	
	void Update () {
		_state.Update();
	}
	
	abstract private class MusicManagerState {
		protected MusicManager _manager;
		
		public MusicManagerState(MusicManager manager) {
			_manager = manager;		
		}
		
		abstract public void Update();
	}
	
	private class NormalMusicState : MusicManagerState {
		public NormalMusicState(MusicManager manager) : base(manager) {
			_manager.audio.clip = _manager.mainMusic;
			_manager.audio.Play();
		}	
		
		override public void Update() {
			if (Input.GetKey(KeyCode.Return)) {
				_manager._state = new IntroBossMusicManagerState(_manager);
			}
		}
	}
	
	private class IntroBossMusicManagerState : MusicManagerState {
		public IntroBossMusicManagerState(MusicManager manager) : base(manager) {
			_manager.audio.clip = _manager.introBossMusic;
			_manager.audio.Play();
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
		}
		
		override public void Update() {
			if (Input.GetKey(KeyCode.Return)) {
				_manager._state = new NormalMusicState(_manager);	
			}
		}
	}
}
