using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject ringPrefab;
	
	private float timeSinceLastMusicTick;
	private float animStartPercentage = 0.8F;
	private MusicManager music;
	private Deplacement player;
	private int z = 0;
	private int _ringJump = 50;
	
	// Use this for initialization
	void Start () {
		music = GameObject.Find("MusicManager").GetComponent<MusicManager>();
		player = GameObject.Find("Player").GetComponent<Deplacement>();
		
		SpawnRings();
	}
	
	// Update is called once per frame
	void Update () {
		float nextTick = 240 / music.bpm;
		timeSinceLastMusicTick += Time.deltaTime;
		
		float minThreshold = nextTick * animStartPercentage;
		if (timeSinceLastMusicTick >= minThreshold) {
			float lengthAnimation = nextTick * (1 - animStartPercentage);
			float deltaAnimation = timeSinceLastMusicTick - minThreshold;
			player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(0, 0, _ringJump/16), deltaAnimation / lengthAnimation);
			Debug.Log(deltaAnimation / lengthAnimation);
			//player.transform.position += new Vector3(0, 0, _ringJump);
			
			if (timeSinceLastMusicTick >= nextTick) {
				timeSinceLastMusicTick = 0;	
			}
		}
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
}
