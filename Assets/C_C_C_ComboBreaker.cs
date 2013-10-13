using UnityEngine;
using System.Collections;

public class C_C_C_ComboBreaker : MonoBehaviour {
	
	public GameObject powPrefab;
	public GameObject player;
	public Texture texture;
	public GameObject animateSpriteSheetPrefab;
	
	private AnimateSpriteSheet animateSpriteSheet;
	
	void Start () 
	{
		this.animateSpriteSheet = GameObject.Find("AnimateSpriteSheet").GetComponent<AnimateSpriteSheet>();
	}
	
	
	void Update () {
	
		/*if (Input.GetKeyDown(KeyCode.Space))
		{				
			Instantiate(this.animateSpriteSheetPrefab, new Vector3(0, 0 , this.player.transform.position.z + 1), animateSpriteSheetPrefab.transform.rotation);
			animateSpriteSheet.Animate(this.player.transform.position.x, this.player.transform.position.y, this.player.transform.position.z + 1);
		}*/
	}
}
